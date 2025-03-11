pub use crate::prelude::*;

pub mod prelude;
pub mod state;

pub async fn on_start(app_handle: &tauri::AppHandle) -> Result<()> {
    println!("EliteAPI: Starting up...");
    app_handle.state::<AppState>();
    Ok(())
}
