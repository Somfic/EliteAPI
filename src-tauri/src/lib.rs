use anyhow::Context;
use serde::Serialize;
use specta_typescript::Typescript;
use tauri::Manager;
use tauri_specta::{collect_events, Builder, Event};
use tokio::sync::Mutex;

type AppState = Mutex<AppData>;

struct AppData {
    has_initialized: bool,
}

impl Default for AppData {
    fn default() -> Self {
        Self {
            has_initialized: false,
        }
    }
}

#[derive(Serialize, Debug, Clone, tauri_specta::Event, specta::Type)]
pub struct JournalEvent(pub String);

pub async fn run() {
    let builder = Builder::<tauri::Wry>::new().events(collect_events![JournalEvent]);

    #[cfg(debug_assertions)]
    builder
        .export(Typescript::default(), "../src/lib/bindings.ts")
        .expect("Failed to export typescript bindings");

    let state = Mutex::new(AppData::default());

    // Start background thread

    tauri::Builder::default()
        .invoke_handler(builder.invoke_handler())
        .setup(move |app| {
            app.manage(state);
            builder.mount_events(app);

            let app_handle = app.handle().clone();
            tokio::spawn(async move {
                let mut reader =
                    match ed_journals::journal::asynchronous::LiveJournalDirReader::open(
                        ed_journals::journal::auto_detect_journal_path().unwrap(),
                    )
                    .context("Failed to open journal directory".to_string())
                    .map_err(|e| e.to_string())
                    {
                        Ok(reader) => reader,
                        Err(e) => {
                            eprintln!("Error: {:?}", e);
                            return;
                        }
                    };

                while let Some(entry) = reader.next().await {
                    match entry {
                        Ok(entry) => {
                            match JournalEvent::emit(
                                &JournalEvent(serde_json::to_string(&entry).unwrap()),
                                &app_handle,
                            ) {
                                Ok(_) => {}
                                Err(e) => {
                                    eprintln!("Error: {:?}", e);
                                }
                            }
                        }
                        Err(e) => {
                            eprintln!("Error: {:?}", e);
                        }
                    }
                }
            });

            Ok(())
        })
        .run(tauri::generate_context!())
        .expect("error while running tauri application");
}
