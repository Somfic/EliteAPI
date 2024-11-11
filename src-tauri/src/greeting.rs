use anyhow::{anyhow, Context};
use serde::Serialize;
use tauri::{http::status, ipc::Channel, AppHandle, Emitter};
use tauri_specta::Event;

use crate::AppState;

#[derive(Serialize, Debug, Clone, tauri_specta::Event, specta::Type)]
pub struct JournalEvent(String);

#[tauri::command]
#[specta::specta]
pub async fn try_initialize(state: tauri::State<'_, AppState>) -> Result<bool, String> {
    let mut state = state.lock().await;

    if state.has_initialized {
        return Ok(false);
    }

    state.has_initialized = true;
    Ok(true)
}

#[tauri::command]
#[specta::specta]
pub async fn read_journal(
    state: tauri::State<'_, AppState>,
    app_handle: AppHandle,
) -> Result<(), String> {
    let state = state.lock().await;

    if state.has_initialized {
        return Err("Not initialized".to_string());
    }

    let mut reader = ed_journals::journal::asynchronous::LiveJournalDirReader::open(
        ed_journals::journal::auto_detect_journal_path().unwrap(),
    )
    .context("Failed to open journal directory".to_string())
    .map_err(|e| e.to_string())?;

    while let Some(entry) = reader.next().await {
        match entry {
            Ok(entry) => {
                println!("{:?}", &entry);
                JournalEvent::emit(
                    &JournalEvent(serde_json::to_string(&entry).unwrap()),
                    &app_handle,
                );
            }
            Err(e) => {
                eprintln!("Error: {:?}", e);
            }
        }
    }

    Ok(())
}
