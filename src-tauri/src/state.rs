use tokio::sync::Mutex;

pub type AppState = Mutex<AppData>;

#[derive(Default)]
pub struct AppData {
    pub is_ready: bool,
}
