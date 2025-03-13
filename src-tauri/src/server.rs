use crate::prelude::*;
use tokio::sync::{mpsc, Mutex};
pub struct Server {
    pub sender: mpsc::Sender<String>,
    pub receiver: Mutex<mpsc::Receiver<String>>,
}

impl Server {
    pub fn new() -> Self {
        let (tx, rx) = mpsc::channel(100);

        Server {
            sender: tx,
            receiver: Mutex::new(rx),
        }
    }

    pub async fn connect(&self) -> Result<()> {
        while let Some(message) = self.receiver.lock().await.recv().await {
            println!("server received: {}", message);
        }

        println!("listener disconnected");

        Ok(())
    }
}
