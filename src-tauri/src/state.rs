use crate::server::Server;
use crate::JournalEvents;
use tokio::sync::Mutex;

pub type AppState = Mutex<AppData>;

pub struct AppData {
    pub server: Server,
    pub events: JournalEvents,
    pub is_ready: bool,
}

impl AppData {
    pub async fn new() -> Self {
        Self {
            server: Server::new(),
            events: JournalEvents::default(),
            is_ready: false,
        }
    }
}
