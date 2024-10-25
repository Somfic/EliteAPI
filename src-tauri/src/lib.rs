use serde::{Deserialize, Serialize};
use specta_typescript::Typescript;
use tauri_specta::{collect_commands, Builder};

#[tauri::command]
#[specta::specta]
fn hello_world(my_name: String) -> String {
    format!("Hello, {my_name}! You've been greeted from Rust through specta!")
}

pub async fn run() {
    let builder = Builder::<tauri::Wry>::new()
        // Then register them (separated by a comma)
        .commands(collect_commands![hello_world,]);

    #[cfg(debug_assertions)] // <- Only export on non-release builds
    builder
        .export(Typescript::default(), "../src/lib/bindings.ts")
        .expect("Failed to export typescript bindings");

    tauri::Builder::default()
        // and finally tell Tauri how to invoke them
        .invoke_handler(builder.invoke_handler())
        .setup(move |app| {
            // This is also required if you want to use events
            builder.mount_events(app);

            Ok(())
        })
        // on an actual app, remove the string argument
        .run(tauri::generate_context!())
        .expect("error while running tauri application");
}
