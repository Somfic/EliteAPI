use crate::server::create_server;
use crate::JournalEvents;
use std::path::Path;
use std::sync::Arc;
use tokio::io::AsyncReadExt;
use tokio::net::windows::named_pipe::{NamedPipeServer, ServerOptions};
use tokio::sync::Mutex;

pub type AppState = Mutex<AppData>;

const PIPE_NAME: &str = r"\\.\pipe\eliteapi";

pub struct AppData {
    pub server: Arc<Mutex<NamedPipeServer>>,
    pub events: JournalEvents,
    pub is_ready: bool,
}

impl AppData {
    pub async fn new() -> Self {
        Self {
            server: create_server().unwrap(),
            events: JournalEvents::default(),
            is_ready: false,
        }
    }
}
