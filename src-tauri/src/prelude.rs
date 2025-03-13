pub use crate::state::AppState;
pub use tauri::Manager;

pub type Result<T> = std::result::Result<T, Error>;

#[derive(Debug, Clone, serde::Serialize)]
pub enum Error {
    JournalError(String),
    Tauri(String),
    JournalPathNotFound,
    ChannelSendError(String),
}
