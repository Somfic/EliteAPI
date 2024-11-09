use std::{path::PathBuf, thread, time::Duration};

use crate::{journal, AppState};

#[tauri::command]
#[specta::specta]
pub fn try_initialize(state: tauri::State<'_, AppState>) -> bool {
    let mut state = state.lock().expect("locked state");

    if state.has_initialized {
        return false;
    }

    state.has_initialized = true;
    return true;
}
