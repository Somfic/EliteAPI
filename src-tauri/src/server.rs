use std::sync::Arc;

use interprocess::local_socket::{prelude::*, GenericNamespaced, ListenerOptions, Stream};
use serde::Serialize;
use std::io::{self, prelude::*, BufReader};
use tokio::{
    io::{split, AsyncReadExt, AsyncWriteExt},
    sync::{broadcast, Mutex},
};

pub struct Server {
    broadcast: broadcast::Sender<String>,
}

const PIPE_NAME: &str = "eliteapi";

impl Server {
    pub fn new() -> Self {
        let (tx, _rx) = broadcast::channel(100);

        Self { broadcast: tx }
    }

    pub fn start(&self) -> Result<(), String> {
        let tx = self.broadcast.clone();
        let name = PIPE_NAME
            .to_ns_name::<GenericNamespaced>()
            .map_err(|e| e.to_string())?;

        let options = ListenerOptions::new().name(name);

        let listener = match options.create_sync() {
            Err(e) if e.kind() == io::ErrorKind::AddrInUse => {
                // When a program that uses a file-type socket name terminates its socket server
                // without deleting the file, a "corpse socket" remains, which can neither be
                // connected to nor reused by a new listener. Normally, Interprocess takes care of
                // this on affected platforms by deleting the socket file when the listener is
                // dropped. (This is vulnerable to all sorts of races and thus can be disabled.)
                // There are multiple ways this error can be handled, if it occurs, but when the
                // listener only comes from Interprocess, it can be assumed that its previous instance
                // either has crashed or simply hasn't exited yet. In this example, we leave cleanup
                // up to the user, but in a real application, you usually don't want to do that.
                eprintln!(
            "Error: could not start server because the socket file is occupied. Please check
            if {PIPE_NAME} is in use by another process and try again."
        );
                return Err(e.to_string());
            }
            x => x.map_err(|e| e.to_string())?,
        };

        println!("Server running at {PIPE_NAME}");

        tokio::spawn(async move {
            let mut buffer = String::with_capacity(128);

            for conn in listener.incoming().filter_map(handle_error) {
                // Wrap the connection into a buffered receiver right away
                // so that we could receive a single line from it.
                let mut conn = BufReader::new(conn);
                println!("Incoming connection!");

                // Since our client example sends first, the server should receive a line and only then
                // send a response. Otherwise, because receiving from and sending to a connection cannot
                // be simultaneous without threads or async, we can deadlock the two processes by having
                // both sides wait for the send buffer to be emptied by the other.
                conn.read_line(&mut buffer).unwrap();

                // Now that the receive has come through and the client is waiting on the server's send, do
                // it. (`.get_mut()` is to get the sender, `BufReader` doesn't implement a pass-through
                // `Write`.)
                conn.get_mut().write_all(b"Hello from server!\n").unwrap();

                // Print out the result, getting the newline for free!
                print!("Client answered: {buffer}");

                // Clear the buffer so that the next iteration will display new data instead of messages
                // stacking on top of one another.
                buffer.clear();
            }
        });

        Ok(())
    }

    pub fn broadcast(&self, commands: &[ServerCommand]) -> Result<(), String> {
        if self.broadcast.receiver_count() == 0 {
            return Ok(());
        }

        let json = serde_json::to_string(commands)
            .map_err(|e| format!("error serializing commands: {}", e))?;

        println!("broadcasting: {}", json);

        self.broadcast
            .send(format!("{}\n", json))
            .map_err(|e| format!("error sending broadcast: {}", e))?;

        Ok(())
    }
}

fn handle_error(conn: io::Result<Stream>) -> Option<Stream> {
    match conn {
        Ok(c) => Some(c),
        Err(e) => {
            eprintln!("Incoming connection failed: {e}");
            None
        }
    }
}

#[derive(Debug, Clone, Serialize)]
pub struct ServerCommand {
    pub _type: CommandType,
    pub _args: Vec<String>,
}

#[derive(Debug, Clone, Serialize)]
pub enum CommandType {
    SetVariable,
    ClearVariable,
    ClearVariablesStartingWith,
    InvokeCommand,
}
