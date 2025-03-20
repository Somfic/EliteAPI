use std::{fs, path::PathBuf};

use notify::{RecommendedWatcher, Watcher};
use tauri::async_runtime::channel;

pub struct FileWatcher {
    pub path: PathBuf,
}

impl FileWatcher {
    pub fn new(path: impl Into<PathBuf>) -> Self {
        let (tx, rx) = channel(1000);

        Self { path: path.into() }
    }

    pub fn watch(&self) -> Result<(), std::io::Error> {
        let path = self.path.clone();
        let watcher = RecommendedWatcher::new(move |res| match res {
            Ok(event) => {
                println!("File changed: {:?}", event);
            }
            Err(e) => {
                eprintln!("Error watching file: {:?}", e);
            }
        })?;
        watcher.watch(path, notify::RecursiveMode::NonRecursive)?;
        Ok(())
    }
}

fn get_last_modified_file(pattern: &str) -> Option<PathBuf> {
    let mut latest: Option<(PathBuf, std::time::SystemTime)> = None;
    for entry in glob::glob(pattern).expect("failed to read glob pattern") {
        if let Ok(path) = entry {
            if let Ok(metadata) = fs::metadata(&path) {
                if let Ok(modified) = metadata.modified() {
                    if latest.as_ref().map_or(true, |&(_, ref t)| modified > *t) {
                        latest = Some((path, modified));
                    }
                }
            }
        }
    }
    latest.map(|(path, _)| path)
}
