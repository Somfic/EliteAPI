use std::sync::Mutex;

use journals::JournalWatcher;
use specta_typescript::Typescript;
use tauri::{
    tray::{MouseButton, TrayIconBuilder, TrayIconEvent},
    AppHandle, Manager, State,
};
use tauri_specta::{collect_commands, Builder};

pub mod journals;

struct AppStateData {
    pub has_initialized: bool,
    pub journal_watcher: JournalWatcher,
}

impl AppStateData {
    fn new() -> Result<Self, anyhow::Error> {
        Ok(Self {
            has_initialized: false,
            journal_watcher: JournalWatcher::init()?,
        })
    }
}

type AppState<'a> = State<'a, Mutex<AppStateData>>;

#[tauri::command]
#[specta::specta]
fn journal_directory(state: AppState) -> String {
    let mut state = state.lock().unwrap();

    state
        .journal_watcher
        .journal_directory
        .display()
        .to_string()
}

#[tauri::command]
#[specta::specta]
fn try_initialize(state: AppState) -> bool {
    let mut state = state.lock().unwrap();
    let has_initialized = state.has_initialized.clone();
    state.has_initialized = true;
    has_initialized
}

#[tauri::command]
#[specta::specta]
fn close() -> () {
    std::process::exit(0);
}

pub async fn run() {
    let builder = Builder::<tauri::Wry>::new().commands(collect_commands![
        journal_directory,
        try_initialize,
        close
    ]);

    #[cfg(debug_assertions)]
    builder
        .export(Typescript::default(), "../src/lib/bindings.ts")
        .expect("Failed to export typescript bindings");

    tauri::Builder::default()
        .invoke_handler(builder.invoke_handler())
        .setup(move |app| {
            app.manage(Mutex::new(AppStateData::new()?));
            builder.mount_events(app);
            Ok(())
        })
        .run(tauri::generate_context!())
        .expect("error while running tauri application");
}
