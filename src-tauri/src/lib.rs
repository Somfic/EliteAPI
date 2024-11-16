use ed_journals::journal::asynchronous::LiveJournalDirReader;
use error::Error;
use serde::Serialize;
use specta_typescript::Typescript;
use state::AppState;
use tauri::Manager;
use tauri_plugin_store::StoreExt;
use tauri_specta::{collect_commands, collect_events, Builder, Event};

pub mod commands;
pub mod error;
pub mod state;

#[derive(Serialize, Debug, Clone, tauri_specta::Event, specta::Type)]
pub struct JournalEvent(pub String);

#[derive(Serialize, Debug, Clone, tauri_specta::Event, specta::Type)]
pub struct ErrorEvent(pub String, pub bool);

pub async fn run() {
    let builder = Builder::<tauri::Wry>::new()
        .events(collect_events![JournalEvent, ErrorEvent])
        .typ::<Preferences>()
        .commands(collect_commands![commands::mark_as_ready]);

    #[cfg(debug_assertions)]
    builder
        .export(Typescript::default(), "../src/lib/bindings.ts")
        .expect("Failed to export typescript bindings");

    tauri::Builder::default()
        .plugin(tauri_plugin_store::Builder::new().build())
        .invoke_handler(builder.invoke_handler())
        .manage(AppState::default())
        .setup(move |app| {
            let preferences = app.store("preferences")?;
            preferences.set("uwu", true);

            builder.mount_events(app);

            async fn setup(app_handle: &tauri::AppHandle) -> Result<(), Error> {
                while !app_handle.state::<AppState>().lock().await.is_ready {
                    tokio::time::sleep(std::time::Duration::from_millis(100)).await;
                }

                println!("Marked as ready, starting journal reader");

                let journal_path = ed_journals::journal::auto_detect_journal_path()
                    .ok_or(Error::JournalDirectoryNotFound)?;

                let mut reader = LiveJournalDirReader::open(journal_path)
                    .map_err(|e| Error::JournalWatcherError(e.to_string()))?;

                while let Some(entry) = reader.next().await {
                    match entry {
                        Ok(entry) => {
                            println!("{:?}", entry);
                            let _ = JournalEvent::emit(
                                &JournalEvent(serde_json::to_string(&entry).unwrap_or_default()),
                                app_handle,
                            );
                        }
                        Err(e) => {
                            send_error_event(
                                &app_handle,
                                Error::JournalWatcherError(e.to_string()),
                                false,
                            );
                            eprintln!("{:?}", e);
                        }
                    }
                }

                println!("Journal reader stopped");
                // TODO: throw error if the journal reader stops

                Ok(())
            }

            tokio::spawn({
                let app_handle = app.handle().clone();
                async move {
                    match setup(&app_handle).await {
                        Ok(_) => {}
                        Err(error) => {
                            println!("Fatal error: {:?}", error);
                            send_error_event(&app_handle, error, true);
                        }
                    }
                }
            });

            Ok(())
        })
        .run(tauri::generate_context!())
        .expect("error while running tauri application");
}

fn send_error_event(app_handle: &tauri::AppHandle, error: Error, is_fatal: bool) {
    let _ = ErrorEvent::emit(&ErrorEvent(error.to_string(), is_fatal), app_handle);
}

#[derive(specta::Type)]
struct Preferences {
    pub uwu: bool,
}
