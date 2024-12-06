use std::sync::Arc;

use tokio::{
    io::{AsyncReadExt, AsyncWriteExt},
    net::windows::named_pipe::{NamedPipeServer, ServerOptions},
    sync::Mutex,
};


struct Server {
    clients: Vec<NamedPipeServer>
}

const PIPE_NAME: &str = r"\\.\pipe\eliteapi";

pub fn create_server() -> Result<Arc<Mutex<NamedPipeServer>>, String> {
    let server = ServerOptions::new()
        .create(PIPE_NAME)
        .map_err(|e| e.to_string())?;

    // Create Mutex
    let server = Arc::new(Mutex::new(server));

    let server_clone = server.clone();

    tokio::spawn(async move {
        handle_client(server_clone).await.unwrap();
    });

    Ok(server)
}

async fn handle_client(server: Arc<Mutex<NamedPipeServer>>) -> Result<(), String> {
    let mut server = server.lock().await;

    server.connect().await.map_err(|e| e.to_string())?;

    let mut buffer = vec![0; 256];

    loop {
        match server.read(&mut buffer).await {
            Ok(bytes_read) => {
                let message = String::from_utf8_lossy(&buffer[..bytes_read]);
                println!("Received: {}", message);

                server.write_all(b"pong!").await.unwrap();
            }
            Err(e) => {
                eprintln!("Error reading from pipe: {}", e);
                break;
            }
        }
    }

    todo!()
}
