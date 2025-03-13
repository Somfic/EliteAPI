pub use crate::prelude::*;
use tauri::async_runtime;

pub mod prelude;
pub mod reader;
pub mod server;
pub mod state;

pub use reader::Reader;
pub use server::Server;

pub async fn on_start(app_handle: &tauri::AppHandle) -> Result<()> {
    // cross process communication
    async_runtime::spawn({
        let app_handle = app_handle.clone();

        async move {
            let state = &mut app_handle.state::<AppState>();
            state.server.connect().await.unwrap();
        }
    });

    // journal reader
    async_runtime::spawn({
        let app_handle = app_handle.clone();

        async move {
            let state = app_handle.state::<AppState>();
            state.reader.read(&state).await.unwrap();
        }
    });

    Ok(())
}
