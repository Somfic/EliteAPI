use greeting::JournalEvent;
use specta_typescript::Typescript;
use tauri::{Listener, Manager};
use tauri_specta::{collect_commands, collect_events, Builder};
use tokio::sync::Mutex;

mod greeting;

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

pub async fn run() {
    let builder = Builder::<tauri::Wry>::new()
        .commands(collect_commands![
            greeting::try_initialize,
            greeting::read_journal
        ])
        .events(collect_events![JournalEvent]);

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
            Ok(())
        })
        .run(tauri::generate_context!())
        .expect("error while running tauri application");
}
