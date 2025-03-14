use crate::prelude::*;
use tauri::{AppHandle, Emitter};
use tokio::sync::{mpsc, Mutex};
use tracing::{info, instrument};

pub struct Server {
    sender: mpsc::Sender<ServerEvent>,
    receiver: Mutex<mpsc::Receiver<ServerEvent>>,
    app_handle: AppHandle,
}

impl Server {
    pub fn new(app_handle: &AppHandle) -> Self {
        let (tx, rx) = mpsc::channel(100);

        Server {
            sender: tx,
            receiver: Mutex::new(rx),
            app_handle: app_handle.clone(),
        }
    }

    pub async fn connect(&self) -> Result<()> {
        println!("server connected");

        while let Some(message) = self.receiver.lock().await.recv().await {
            println!("server received: {:?}", message);
        }

        println!("listener disconnected");

        Ok(())
    }

    pub async fn emit(&self, event: ServerEvent) -> Result<()> {
        self.sender
            .send(event.clone())
            .await
            .map_err(|e| Error::ChannelSendError(e.to_string()))?;

        match event {
            ServerEvent::Log(log) => self
                .app_handle
                .emit("log", log)
                .map_err(|e| Error::ChannelSendError(e.to_string()))?,
            ServerEvent::JournalEvent(journal_event) => self
                .app_handle
                .emit("journal_event", journal_event)
                .map_err(|e| Error::ChannelSendError(e.to_string()))?,
            ServerEvent::Error(error) => self
                .app_handle
                .emit("error", error)
                .map_err(|e| Error::ChannelSendError(e.to_string()))?,
        };

        Ok(())
    }
}

#[derive(Debug, Clone, serde::Serialize)]
pub enum ServerEvent {
    Log(String),
    Error(crate::Error),
    JournalEvent(ed_journals::journal::JournalEvent),
}
