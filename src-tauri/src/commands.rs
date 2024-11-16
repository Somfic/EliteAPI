use crate::state::AppState;

#[tauri::command]
#[specta::specta]
pub async fn mark_as_ready(state: tauri::State<'_, AppState>) -> Result<(), ()> {
    let mut state = state.lock().await;
    state.is_ready = true;

    Ok(())
}
