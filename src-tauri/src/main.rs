#![cfg_attr(not(debug_assertions), windows_subsystem = "windows")]

pub use eliteapi::prelude::*;

#[tokio::main]
async fn main() {
    let spec_builder = tauri_specta::Builder::<tauri::Wry>::new()
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
        .manage(AppState::new())
        .setup(move |app| {
            spec_builder.mount_events(app);

            tauri::async_runtime::spawn({
                let app_handle = app.handle().clone();
                async move {
                    match eliteapi::on_start(&app_handle).await {
                        Ok(_) => {}
                        Err(error) => {
                            panic!("fatal error: {:?}", error);
                        }
                    }
                }
            });

            Ok(())
        })
        .run(tauri::generate_context!())
        .expect("error while running tauri application");
}
