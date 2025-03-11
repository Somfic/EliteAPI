use serde::Serialize;

pub use crate::state::AppState;
pub use tauri::Manager;

pub type Result<T> = std::result::Result<T, Error>;
pub type Error = Box<dyn std::error::Error + Send + Sync>;
