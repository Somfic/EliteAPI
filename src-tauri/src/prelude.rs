pub use crate::state::AppState;
pub use tauri::Manager;

pub type Result<T> = std::result::Result<T, Error>;

#[derive(Debug, Clone, serde::Serialize, specta::Type)]
pub enum Error {
    JournalError(String),
    Tauri(String),
    JournalPathNotFound,
    ChannelSendError(String),
}
