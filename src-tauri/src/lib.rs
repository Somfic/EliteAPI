use anyhow::{anyhow, Context};
use serde::Serialize;
use specta_typescript::Typescript;
use tauri::Manager;
use tauri_specta::{collect_events, Builder, Event};
use tokio::sync::Mutex;

type AppState = Mutex<AppData>;

struct AppData {}

impl Default for AppData {
    fn default() -> Self {
        Self {}
    }
}

#[derive(Serialize, Debug, Clone, tauri_specta::Event, specta::Type)]
pub struct JournalEvent(pub String);

#[derive(Serialize, Debug, Clone, tauri_specta::Event, specta::Type)]
pub struct ErrorEvent(pub String);

pub async fn run() {
    let builder = Builder::<tauri::Wry>::new().events(collect_events![JournalEvent, ErrorEvent]);

    #[cfg(debug_assertions)]
    builder
        .export(Typescript::default(), "../src/lib/bindings.ts")
        .expect("Failed to export typescript bindings");

    tauri::Builder::default()
        .invoke_handler(builder.invoke_handler())
        .setup(move |app| {
            builder.mount_events(app);

            async fn setup(app_handle: &tauri::AppHandle) -> anyhow::Result<()> {
                let mut reader = ed_journals::journal::asynchronous::LiveJournalDirReader::open(
                    ed_journals::journal::auto_detect_journal_path()
                        .context("Failed to auto-detect journal path")?,
                )?;

                while let Some(entry) = reader.next().await {
                    match entry {
                        Ok(entry) => {
                            println!("{:?}", entry);
                            JournalEvent::emit(
                                &JournalEvent(serde_json::to_string(&entry).unwrap()),
                                app_handle,
                            )
                            .context("Could not emit journal event")?;
                        }
                        Err(e) => {
                            ErrorEvent::emit(&ErrorEvent(e.to_string()), app_handle)
                                .context("Could parse journal event")?;
                        }
                    }
                }

                Ok(())
            }

            tokio::spawn({
                let app_handle = app.handle().clone();
                async move {
                    match setup(&app_handle).await {
                        Ok(_) => {}
                        Err(e) => {
                            println!("Error: {:?}", e);
                            let _ = ErrorEvent::emit(&ErrorEvent(e.to_string()), &app_handle);
                        }
                    }
                }
            });

            Ok(())
        })
        .run(tauri::generate_context!())
        .expect("error while running tauri application");
}
