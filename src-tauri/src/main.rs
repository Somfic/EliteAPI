#![cfg_attr(not(debug_assertions), windows_subsystem = "windows")]

use eliteapi::{events::*, prelude::*};
use tauri_specta::collect_events;
use tracing::{debug, error};

#[tokio::main]
async fn main() {
    tracing_subscriber::fmt()
        .with_max_level(tracing::Level::DEBUG)
        .with_line_number(true)
        .compact()
        .init();

    let spec_builder = tauri_specta::Builder::<tauri::Wry>::new()
        .events(collect_events![LogEvent, ErrorEvent, JournalEvent, VariablesEvent])
        //.commands(collect_commands![commands::get_event_backlog])
        //.events(collect_events![events::journal_event]),
        //.typ()
        ;

    #[cfg(debug_assertions)]
    spec_builder
        .export(
            specta_typescript::Typescript::default(),
            "../src/lib/bindings.ts",
        )
        .expect("Failed to export typescript bindings");

    tauri::Builder::default()
        .plugin(tauri_plugin_store::Builder::new().build())
        .invoke_handler(spec_builder.invoke_handler())
        .setup(move |app| {
            spec_builder.mount_events(app);

            app.manage(AppState::new(app.handle()));

            tauri::async_runtime::spawn({
                let app_handle = app.handle().clone();
                async move {
                    match eliteapi::on_start(&app_handle).await {
                        Ok(_) => {}
                        Err(error) => {
                            error!("fatal error: {:?}", error);
                            debug!("exiting application");
                            app_handle.exit(1);
                        }
                    }
                }
            });

            Ok(())
        })
        .run(tauri::generate_context!())
        .expect("error while running tauri application");
}
