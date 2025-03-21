// use crate::prelude::*;
// use notify::{recommended_watcher, RecommendedWatcher, Watcher};
// use std::{fs, path::PathBuf};
// use tauri::async_runtime::channel;
// use tokio::sync::mpsc;

// pub struct FileWatcher {
//     pub path: PathBuf,
//     pub tx: mpsc::Sender<String>,
//     pub rx: mpsc::Receiver<String>,
// }

// impl FileWatcher {
//     pub fn new(path: impl Into<PathBuf>) -> Self {
//         let (tx, rx) = channel::<String>(1000);
//         let path = path.into();

//         FileWatcher { path, tx, rx }
//     }

//     pub async fn watch(&self) {
//         let watcher = RecommendedWatcher::new(move |res| match res {
//             Ok(event) => {
//                 if let Some(path) = event.paths.get(0) {
//                     if path == &self.path {
//                         let _ = self.tx.send(path.to_string_lossy().to_string()).await;
//                     }
//                 }
//             }
//             Err(e) => eprintln!("watch error: {:?}", e),
//         });

//         todo!()
//     }
// }

// fn get_last_modified_file(pattern: &str) -> Option<PathBuf> {
//     let mut latest: Option<(PathBuf, std::time::SystemTime)> = None;
//     for entry in glob::glob(pattern).expect("failed to read glob pattern") {
//         if let Ok(path) = entry {
//             if let Ok(metadata) = fs::metadata(&path) {
//                 if let Ok(modified) = metadata.modified() {
//                     if latest.as_ref().map_or(true, |&(_, ref t)| modified > *t) {
//                         latest = Some((path, modified));
//                     }
//                 }
//             }
//         }
//     }
//     latest.map(|(path, _)| path)
// }
