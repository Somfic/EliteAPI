pub use crate::prelude::*;
use tauri::async_runtime;

pub mod events;
pub mod keybindings;
pub mod prelude;
pub mod reader;
pub mod server;
pub mod state;

pub use reader::Reader;
pub use server::Server;
use tracing::{info, instrument, span, warn};

#[instrument]
pub async fn on_start(app_handle: &tauri::AppHandle) -> Result<()> {
    // cross process communication
    async_runtime::spawn({
        let app_handle = app_handle.clone();

        async move {
            let span = span!(tracing::Level::DEBUG, "ipc");
            let _scope = span.enter();
            let ipc = ipc(app_handle).await;

            if let Err(e) = ipc {
                warn!("error: {:?}", e);
            }
        }
    });

    // journal reader
    async_runtime::spawn({
        let app_handle = app_handle.clone();

        async move {
            let span = span!(tracing::Level::DEBUG, "reader");
            let _scope = span.enter();
            let reader = reader(app_handle).await;

            if let Err(e) = reader {
                warn!("error: {:?}", e);
            }
        }
    });

    // status
    async_runtime::spawn({
        let app_handle = app_handle.clone();

        async move {
            let span = span!(tracing::Level::DEBUG, "status");
            let _scope = span.enter();
            loop {
                tokio::time::sleep(std::time::Duration::from_secs(1)).await;
                let state = app_handle.state::<AppState>();
                info!("voiceattack: {:?}", state.server.clients.lock().await.len());
            }
        }
    });

    Ok(())
}

async fn ipc(app_handle: tauri::AppHandle) -> Result<()> {
    let state = app_handle.state::<AppState>();
    state.server.connect().await
}

async fn reader(app_handle: tauri::AppHandle) -> Result<()> {
    let state = app_handle.state::<AppState>();
    state.reader.read(&state).await
}
