pub use crate::prelude::*;

pub mod prelude;
pub mod reader;
pub mod state;

pub use reader::Reader;

pub async fn on_start(app_handle: &tauri::AppHandle) -> Result<()> {
    println!("EliteAPI: Starting up...");

    tauri::async_runtime::spawn({
        let app_handle = app_handle.clone();
        let state = app_handle.state::<AppState>();

        println!("starting listener");

        let mut listener = state.reader.sender.subscribe();

        println!("waiting for messages");

        async move {
            loop {
                match listener.recv().await {
                    Ok(message) => {
                        println!("Listener: received message: {}", message);
                    }
                    Err(e) => {
                        println!("Error receiving message: {}", e);
                    }
                }
            }
        }
    });

    tauri::async_runtime::spawn({
        let app_handle = app_handle.clone();

        async move {
            let state = app_handle.state::<AppState>();
            state.reader.read().await.unwrap();
        }
    });

    Ok(())
}
