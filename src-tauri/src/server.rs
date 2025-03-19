use crate::events::*;
use crate::{prelude::*, reader::JsonValuePath};
use interprocess::local_socket::tokio::Listener;
use std::sync::Arc;
use tauri::{AppHandle, Emitter};
use tauri_specta::Event;
use tokio::sync::{mpsc, Mutex};
use tracing::{debug, field::debug, info, instrument, trace, warn};
use {
    interprocess::local_socket::{
        tokio::{prelude::*, Stream},
        GenericNamespaced, ListenerOptions,
    },
    std::io,
    tokio::{
        io::{AsyncBufReadExt, AsyncWriteExt, BufReader},
        try_join,
    },
};

const SOCKET_NAME: &str = "eliteapi.sock";

pub struct Server {
    sender: mpsc::Sender<ServerEvent>,
    receiver: Mutex<mpsc::Receiver<ServerEvent>>,
    app_handle: AppHandle,
    clients: Arc<Mutex<Vec<LocalSocketStream>>>,
}

impl Server {
    pub fn new(app_handle: &AppHandle) -> Self {
        let (tx, rx) = mpsc::channel(100);

        let clients = Arc::new(Mutex::new(Vec::new()));

        Self::spawn_accept_loop(clients.clone());

        Server {
            sender: tx,
            receiver: Mutex::new(rx),
            app_handle: app_handle.clone(),
            clients,
        }
    }

    pub async fn connect(&self) -> Result<()> {
        debug!("opening connection");

        while let Some(message) = self.receiver.lock().await.recv().await {
            trace!("{:?}", message);
        }

        warn!("connection closed");

        Ok(())
    }

    pub async fn emit(&self, event: ServerEvent) -> Result<()> {
        // send the event to the channel
        self.sender
            .send(event.clone())
            .await
            .map_err(|e| Error::ChannelSendError(e.to_string()))?;

        // send the event to the frontend
        match &event {
            ServerEvent::Log(log) => LogEvent::emit(log, &self.app_handle),
            ServerEvent::JournalEvent(journal_event) => {
                JournalEvent::emit(journal_event, &self.app_handle)
            }
            ServerEvent::Error(error) => ErrorEvent::emit(error, &self.app_handle),
            ServerEvent::VariablesEvent(variables_event) => {
                VariablesEvent::emit(variables_event, &self.app_handle)
            }
        }
        .map_err(|e| Error::ChannelSendError(e.to_string()))?;

        // send th event to the local socket
        self.broadcast_event(&event).await?;

        Ok(())
    }

    fn spawn_accept_loop(clients: Arc<Mutex<Vec<LocalSocketStream>>>) {
        let name = match SOCKET_NAME.to_ns_name::<GenericNamespaced>() {
            Ok(n) => n,
            Err(e) => {
                warn!("failed to convert socket name: {:?}", e);
                return;
            }
        };
        let opts = ListenerOptions::new().name(name);

        let listener = match opts.create_tokio() {
            Ok(listener) => listener,
            Err(e) => {
                warn!("failed to create listener: {:?}", e);
                return;
            }
        };

        tokio::spawn(async move {
            loop {
                let connection = match listener.accept().await {
                    Ok(connection) => connection,
                    Err(e) => {
                        warn!("failed to accept connection: {:?}", e);
                        continue;
                    }
                };

                clients.lock().await.push(connection);
            }
        });
    }

    async fn broadcast_event(&self, event: &ServerEvent) -> Result<()> {
        trace!("broadcasting {:?}", event);
        let serialized =
            serde_json::to_string(event).map_err(|e| Error::JsonError(e.to_string()))? + "\n";
        let mut clients_guard = self.clients.lock().await;
        let mut i = 0;
        while i < clients_guard.len() {
            if let Err(e) = clients_guard[i].write_all(serialized.as_bytes()).await {
                warn!("failed to write to client, dropping connection: {:?}", e);
                clients_guard.remove(i);
            } else {
                i += 1;
            }
        }
        Ok(())
    }
}
