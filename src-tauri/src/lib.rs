pub use crate::prelude::*;
use tauri::async_runtime;

pub mod prelude;
pub mod reader;
pub mod server;
pub mod state;

pub use reader::Reader;
pub use server::Server;

pub async fn on_start(app_handle: &tauri::AppHandle) -> Result<()> {
    println!("EliteAPI: Starting up...");

    async_runtime::spawn({
        let app_handle = app_handle.clone();

        async move {
            let state = app_handle.state::<AppState>();
            state
                .reader
                .read(state.server.sender.clone())
                .await
                .unwrap();
        }
    });

    async_runtime::spawn({
        let app_handle = app_handle.clone();

        async move {
            let state = &mut app_handle.state::<AppState>();
            state.server.connect().await.unwrap();
        }
    });

    Ok(())
}
