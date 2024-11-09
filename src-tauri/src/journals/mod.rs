use anyhow::Result;
use directories::UserDirs;
use notify::{RecursiveMode, Watcher};
use serde::Serialize;
use std::path::PathBuf;
use tauri::{ipc::Channel, AppHandle, Emitter};

pub struct JournalWatcher {
    pub journal_directory: PathBuf,
    pub watcher: notify::RecommendedWatcher,
}

impl JournalWatcher {
    pub fn init() -> Result<Self> {
        let mut watcher = notify::recommended_watcher(move |res| match res {
            Ok(event) => println!("{:?}", event),
            Err(e) => {
                eprintln!("watch error: {:?}", e);
            }
        })?;

        let journal_directory = find_journal_directory().ok_or_else(|| {
            anyhow::anyhow!("Could not find the Elite: Dangerous journals directory")
        })?;

        watcher.watch(journal_directory.as_path(), RecursiveMode::Recursive)?;

        Ok(Self {
            journal_directory: find_journal_directory().ok_or_else(|| {
                anyhow::anyhow!("Could not find the Elite: Dangerous journals directory")
            })?,
            watcher,
        })
    }
}

fn find_journal_directory() -> Option<PathBuf> {
    #[cfg(target_family = "windows")]
    {
        let expected_path = UserDirs::new()?
            .home_dir()
            .join("Saved Games")
            .join("Frontier Developments")
            .join("Elite Dangerous");

        if !expected_path.exists() {
            return None;
        }

        return Some(expected_path);
    }

    #[cfg(target_family = "unix")]
    {
        let user_dir = UserDirs::new()?;

        return [
            user_dir.home_dir().join(".local/share/Steam/compatibilitytools.d/Proton 3.16-8 Beta ED/dist/share/default_pfx/drive_c/users/steamuser/Saved Games/Frontier Developments/Elite Dangerous"),
            user_dir.home_dir().join(".local/share/Steam/steamapps/common/Elite Dangerous/Products/elite-dangerous-64/Logs/Saved Games/Frontier Developments/Elite Dangerous"),
            user_dir.home_dir().join(".local/share/Steam/steamapps/common/Proton 4.2/dist/share/default_pfx/drive_c/users/steamuser/Saved Games/Frontier Developments/Elite Dangerous"),
            user_dir.home_dir().join(".local/share/Steam/steamapps/compatdata/359320/pfx/drive_c/users/steamuser/Saved Games/Frontier Developments/Elite Dangerous"),
        ]
            .into_iter()
            .find(|path| path.exists());
    }
}
