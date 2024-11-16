use serde::Serialize;
use thiserror::Error;

#[derive(Serialize, Clone, Error, Debug, specta::Type)]
pub enum Error {
    #[error("{0}")]
    JournalWatcherError(String),
    #[error("Could not communicate between frontend and backend.")]
    CommunicationError,
    #[error("Could not find the journal directory.")]
    JournalDirectoryNotFound,
}
