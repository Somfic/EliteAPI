use std::sync::Mutex;

use specta_typescript::Typescript;
use tauri::{Listener, Manager};
use tauri_specta::{collect_commands, Builder};

mod greeting;
mod journal;

type AppState = Mutex<AppData>;

struct AppData {
    welcome_message: &'static str,
}

impl Default for AppData {
    fn default() -> Self {
        Self {
            welcome_message: "Hello, World!",
        }
    }
}

pub async fn run() {
    let builder = Builder::<tauri::Wry>::new().commands(collect_commands![
        // greeting::hello_world,
        // greeting::run_infinite_loop,
        // greeting::find_directory
    ]);

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
