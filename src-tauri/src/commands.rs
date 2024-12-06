use crate::{state::AppState, JournalEvent};
use tauri_specta::Event;

#[tauri::command]
#[specta::specta]
pub async fn mark_as_ready(state: tauri::State<'_, AppState>) -> Result<(), ()> {
    let mut state = state.lock().await;
    state.is_ready = true;

    Ok(())
}

#[tauri::command]
#[specta::specta]
pub async fn get_event_backlog(
    state: tauri::State<'_, AppState>,
    app_handle: tauri::AppHandle,
) -> Result<(), ()> {
    let state = state.lock().await;

    for event in state.events.get() {
        let mut event = event.clone();
        event.is_live = false;
        let json = serde_json::to_string(&event).unwrap_or_default();
        let _ = JournalEvent::emit(&JournalEvent(json), &app_handle);
    }

    Ok(())
}
