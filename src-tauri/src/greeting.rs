use std::{path::PathBuf, thread, time::Duration};

use crate::{journal, AppState};

#[tauri::command]
#[specta::specta]
pub fn hello_world(my_name: String) -> String {
    format!("Hello, {my_name}! You've been greeted from Rust through specta!")
}

#[tauri::command]
#[specta::specta]
pub fn watch_directory(state: tauri::State<'_, AppState>) {
    let mut state = state.lock().expect("locked state");

    state.welcome_message = "Watching directory...";
}
