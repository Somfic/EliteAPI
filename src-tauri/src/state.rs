use crate::server::Server;
use crate::JournalEvents;
use tokio::sync::Mutex;

pub struct AppState {
    pub server: Server,
    pub events: Mutex<JournalEvents>,
    pub is_ready: bool,
}

impl AppState {
    pub fn new() -> Self {
        Self {
            server: Server::new(),
            events: Mutex::new(JournalEvents::default()),
            is_ready: false,
        }
    }
}
