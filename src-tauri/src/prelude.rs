use serde::Serialize;

pub use crate::state::AppState;
pub use tauri::Manager;

pub type Result<T> = std::result::Result<T, Error>;

#[derive(Serialize, Clone, thiserror::Error, Debug, specta::Type)]
pub enum Error {
    #[error("{0}")]
    JournalWatcherError(String),
    #[error("Could not communicate between frontend and backend.")]
    CommunicationError,
    #[error("Could not find the journal directory.")]
    JournalDirectoryNotFound,
}
