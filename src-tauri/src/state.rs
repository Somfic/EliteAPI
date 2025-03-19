use tauri::AppHandle;

use crate::{Reader, Server};

pub struct AppState {
    pub server: Server,
    pub reader: Reader,
}

impl AppState {
    pub fn new(app_handle: &AppHandle) -> Self {
        AppState {
            server: Server::new(app_handle),
            reader: Reader::new(),
        }
    }
}
