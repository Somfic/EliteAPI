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
        let state = app_handle.state::<AppState>();

        let json: String = serde_json::to_string(event).map_err(|e| e.to_string())?;
        self.events.push(event.clone());

        JournalEvent::emit(&JournalEvent(json.clone()), app_handle).map_err(|e| e.to_string())?;

        let mut commands = Vec::new();

        let (category, event_name, event_json) = match &event.kind {
            ed_journals::journal::JournalEventKind::LogEvent(log_event) => (
                "Journal".to_string(),
                log_event.content.kind().to_string(),
                serde_json::to_string(&log_event.content),
            ),
            ed_journals::journal::JournalEventKind::StatusEvent(status) => (
                "Status".to_string(),
                "Status".to_string(),
                serde_json::to_string(status),
            ),
            ed_journals::journal::JournalEventKind::OutfittingEvent(outfitting) => (
                "Outfitting".to_string(),
                "Outfitting".to_string(),
                serde_json::to_string(outfitting),
            ),
            ed_journals::journal::JournalEventKind::ShipyardEvent(shipyard) => (
                "Shipyard".to_string(),
                "Shipyard".to_string(),
                serde_json::to_string(shipyard),
            ),
            ed_journals::journal::JournalEventKind::MarketEvent(market) => (
                "Market".to_string(),
                "Market".to_string(),
                serde_json::to_string(market),
            ),
            ed_journals::journal::JournalEventKind::NavRoute(nav_route) => (
                "NavRoute".to_string(),
                "NavRoute".to_string(),
                serde_json::to_string(nav_route),
            ),
            ed_journals::journal::JournalEventKind::ModulesInfo(modules) => (
                "ModulesInfo".to_string(),
                "ModulesInfo".to_string(),
                serde_json::to_string(modules),
            ),
            ed_journals::journal::JournalEventKind::Backpack(backpack) => (
                "Backpack".to_string(),
                "Backpack".to_string(),
                serde_json::to_string(backpack),
            ),
            ed_journals::journal::JournalEventKind::Cargo(cargo) => (
                "Cargo".to_string(),
                "Cargo".to_string(),
                serde_json::to_string(cargo),
            ),
            ed_journals::journal::JournalEventKind::ShipLocker(ship_locker) => (
                "ShipLocker".to_string(),
                "ShipLocker".to_string(),
                serde_json::to_string(ship_locker),
            ),
        };

        let event_json = event_json.map_err(|e| e.to_string())?;
        let variables = json_to_paths(&event_name, &event_json);

        commands.push(server::ServerCommand {
            _type: server::CommandType::ClearVariablesStartingWith,
            _args: vec![format!("{}.", &event_name)],
        });
        for variable in variables {
            commands.push(server::ServerCommand {
                _type: server::CommandType::SetVariable,
                _args: vec![
                    category.clone(),
                    variable.path,
                    format!("{:?}", variable.value_type),
                    variable.encoded_value,
                ],
            });
        }
        commands.push(server::ServerCommand {
            _type: server::CommandType::InvokeCommand,
            _args: vec![event_name.to_string()],
        });

        state
            .server
            .broadcast(&commands)
            .map_err(|e| e.to_string())?;

        Ok(())
    }

    pub fn get(&self) -> &Vec<ed_journals::journal::JournalEvent> {
        self.events.as_ref()
    }
}

#[derive(Debug, Clone, Serialize)]
struct JsonPath {
    path: String,
    encoded_value: String,
    value_type: ValueType,
}

#[derive(Debug, Clone, Serialize)]
enum ValueType {
    String,
    Int32,
    Single,
    Boolean,
    DateTime,
}

fn json_to_paths(event_name: &str, json: &str) -> Vec<JsonPath> {
    // Converts a json string to a list of paths
    // Example:
    // {"a": {"b": 1, "c": 2}, "d": [1, 2, 3]}
    // becomes:
    // ["a.b", "a.c", "d.0", "d.1", "d.2"]

    let mut paths: Vec<JsonPath> = Vec::new();

    let json: serde_json::Value = serde_json::from_str(json).unwrap();

    fn recurse(json: &serde_json::Value, path: &str, paths: &mut Vec<JsonPath>) {
        match json {
            serde_json::Value::Object(map) => {
                for (key, value) in map {
                    let new_path = format!("{}.{}", path, key);
                    recurse(value, &new_path, paths);
                }
            }
            serde_json::Value::Array(array) => {
                for (i, value) in array.iter().enumerate() {
                    let new_path = format!("{}[{}]", path, i);
                    recurse(value, &new_path, paths);
                }
            }
            json_value => {
                paths.push(JsonPath {
                    path: path.to_string(),
                    encoded_value: json.to_string(),
                    value_type: match json_value {
                        serde_json::Value::String(_) => ValueType::String,
                        serde_json::Value::Number(_) => match json_value.as_i64() {
                            Some(_) => ValueType::Int32,
                            None => ValueType::Single,
                        },
                        serde_json::Value::Bool(_) => ValueType::Boolean,
                        serde_json::Value::Null => ValueType::String,
                        _ => ValueType::String,
                    },
                });
            }
        }
    }

    recurse(&json, event_name, &mut paths);

    paths
}

#[derive(Serialize, Debug, Clone, tauri_specta::Event, specta::Type)]
pub struct ErrorEvent(pub String, pub bool);

pub async fn run() {
    let builder = Builder::<tauri::Wry>::new()
        .events(collect_events![JournalEvent, ErrorEvent])
        .typ::<Preferences>()
        .commands(collect_commands![commands::get_event_backlog]);

    #[cfg(debug_assertions)]
    builder
        .export(Typescript::default(), "../src/lib/bindings.ts")
        .expect("Failed to export typescript bindings");

    tauri::Builder::default()
        .plugin(tauri_plugin_store::Builder::new().build())
        .invoke_handler(builder.invoke_handler())
        .manage(AppState::new())
        .setup(move |app| {
            let preferences = app.store("preferences")?;
            preferences.set("uwu", true);

            builder.mount_events(app);

            async fn setup(app_handle: &tauri::AppHandle) -> Result<(), Error> {
                let journal_path = ed_journals::journal::auto_detect_journal_path()
                    .ok_or(Error::JournalDirectoryNotFound)?;

                let mut reader = LiveJournalDirReader::open(journal_path)
                    .map_err(|e| Error::JournalWatcherError(e.to_string()))?;

                while let Some(entry) = reader.next().await {
                    match entry {
                        Ok(entry) => {
                            let state = app_handle.state::<AppState>();
                            {
                                state
                                    .events
                                    .lock()
                                    .await
                                    .emit(&entry, app_handle)
                                    .await
                                    .unwrap();
                            }
                        }
                        Err(e) => {
                            send_error_event(
                                &app_handle,
                                Error::JournalWatcherError(e.to_string()),
                                false,
                            );
                            eprintln!("error: {:?}", e);
                        }
                    }
                }

                Ok(())
            }

            tauri::async_runtime::spawn({
                let app_handle = app.handle().clone();
                async move {
                    match setup(&app_handle).await {
                        Ok(_) => {}
                        Err(error) => {
                            eprintln!("fatal error: {:?}", error);
                            send_error_event(&app_handle, error, true);
                        }
                    }
                }
            });

            tauri::async_runtime::spawn({
                let app_handle = app.handle().clone();
                async move {
                    let state = app_handle.state::<AppState>();
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
