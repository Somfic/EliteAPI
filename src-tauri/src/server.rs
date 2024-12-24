use std::sync::Arc;

use tokio::{
    io::{split, AsyncReadExt, AsyncWriteExt},
    net::windows::named_pipe::{NamedPipeServer, PipeMode, ServerOptions},
    sync::{broadcast, Mutex},
};

pub struct Server {
    broadcast: broadcast::Sender<String>,
}

const PIPE_NAME: &str = r"\\.\pipe\eliteapi";

impl Server {
    pub fn new() -> Self {
        let (tx, _rx) = broadcast::channel(100);

        Self { broadcast: tx }
    }

    pub fn start(&self) -> Result<(), String> {
        let tx = self.broadcast.clone();

        // Spawn the server loop.
        tokio::spawn(async move {
            loop {
                println!("Waiting for client to connect...");

                let server = match ServerOptions::new()
                    .pipe_mode(PipeMode::Message)
                    //.first_pipe_instance(true)
                    .create(PIPE_NAME)
                {
                    Ok(server) => server,
                    Err(err) => {
                        eprintln!("error creating server: {}", err);
                        tokio::time::sleep(std::time::Duration::from_secs(1)).await;
                        continue;
                    }
                };

                // Wait for a client to connect.
                if let Err(err) = server.connect().await {
                    eprintln!("error connecting to client: {}", err);
                    tokio::time::sleep(std::time::Duration::from_secs(1)).await;
                    continue;
                }

                let broadcast: broadcast::Sender<String> = tx.clone();
                tokio::spawn(async move {
                    if let Err(e) = handle_client(server, broadcast).await {
                        eprintln!("client error: {}", e);
                    }
                });
            }
        });

        Ok(())
    }

    pub fn broadcast(&self, msg: String) {
        // TODO: handle errors
        let _ = self.broadcast.send(msg);
    }
}

async fn handle_client(
    client: NamedPipeServer,
    broadcast: broadcast::Sender<String>,
) -> Result<(), String> {
    let mut broadcast = broadcast.subscribe();

    let (mut reader, writer) = split(client);
    let writer = Arc::new(Mutex::new(writer));

    // spawn a task to forward broadcasted messages to this client
    let write_clone = Arc::clone(&writer);
    tokio::spawn(async move {
        while let Ok(msg) = broadcast.recv().await {
            let mut write_clone = write_clone.lock().await;
            if let Err(e) = write_clone.write_all(msg.as_bytes()).await {
                eprintln!("error sending broadcast to client: {}", e);
                break;
            }
            if let Err(e) = write_clone.write_all(b"\n").await {
                eprintln!("error sending newline to client: {}", e);
                break;
            }
        }
    });

    let mut buf = vec![0; 1024];
    loop {
        let n = match reader.read(&mut buf).await {
            Ok(n) if n == 0 => break, // client disconnected
            Ok(n) => n,
            Err(e) => return Err(format!("error reading from client: {}", e)),
        };

        let msg = String::from_utf8_lossy(&buf[..n]).trim().to_string();
        if msg == "ping" {
            let mut writer = writer.lock().await;
            if let Err(e) = writer.write_all(b"pong\n").await {
                return Err(format!("error sending pong to client: {}", e));
            }
        } else {
            println!("received from client: {}", msg);
        }
    }

    Ok(())
}
