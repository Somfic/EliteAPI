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
pub mod server;
pub mod state;

#[derive(Serialize, Debug, Clone, tauri_specta::Event, specta::Type)]
pub struct JournalEvent(pub String);

// store sent journalevents in a store so that we can access them later
#[derive(Default)]
pub struct JournalEvents {
    pub events: Vec<ed_journals::journal::JournalEvent>,
}

impl JournalEvents {
    pub async fn emit(
        &mut self,
        event: &ed_journals::journal::JournalEvent,
        app_handle: &tauri::AppHandle,
    ) -> Result<(), String> {
        println!("Locking state");

        let state = app_handle.state::<AppState>();
        let state = state.lock().await;

        println!("State locked");

        let json = serde_json::to_string(event).map_err(|e| e.to_string())?;
        self.events.push(event.clone());

        println!("Emitting event: {}", json);

        let _ = JournalEvent::emit(&JournalEvent(json.clone()), app_handle);

        println!("Event emitted: {}", json);

        state.server.broadcast(json);

        println!("Event sent to server");

        Ok(())
    }

    pub fn get(&self) -> &Vec<ed_journals::journal::JournalEvent> {
        self.events.as_ref()
    }
}

#[derive(Serialize, Debug, Clone, tauri_specta::Event, specta::Type)]
pub struct ErrorEvent(pub String, pub bool);

pub async fn run() {
    let builder = Builder::<tauri::Wry>::new()
        .events(collect_events![JournalEvent, ErrorEvent])
        .typ::<Preferences>()
        .commands(collect_commands![
            commands::mark_as_ready,
            commands::get_event_backlog
        ]);

    #[cfg(debug_assertions)]
    builder
        .export(Typescript::default(), "../src/lib/bindings.ts")
        .expect("Failed to export typescript bindings");

    tauri::Builder::default()
        .plugin(tauri_plugin_store::Builder::new().build())
        .invoke_handler(builder.invoke_handler())
        .manage(AppState::new(state::AppData::new().await))
        .setup(move |app| {
            let preferences = app.store("preferences")?;
            preferences.set("uwu", true);

            builder.mount_events(app);

            async fn setup(app_handle: &tauri::AppHandle) -> Result<(), Error> {
                println!("Starting journal reader");

                let journal_path = ed_journals::journal::auto_detect_journal_path()
                    .ok_or(Error::JournalDirectoryNotFound)?;

                let mut reader = LiveJournalDirReader::open(journal_path)
                    .map_err(|e| Error::JournalWatcherError(e.to_string()))?;

                println!("Journal reader started");

                while let Some(entry) = reader.next().await {
                    match entry {
                        Ok(entry) => {
                            let state = app_handle.state::<AppState>();
                            {
                                let mut state = state.lock().await;
                                println!("{:?}", entry);
                                println!("Emitting event");
                                state.events.emit(&entry, app_handle).await.unwrap();
                                println!("Event emitted");
                            }
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
                Ok(())
            }

            tauri::async_runtime::spawn({
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

            tauri::async_runtime::spawn({
                let app_handle = app.handle().clone();
                async move {
                    let state = app_handle.state::<AppState>();
                    let state = state.lock().await;
                    state.server.start().unwrap();
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
