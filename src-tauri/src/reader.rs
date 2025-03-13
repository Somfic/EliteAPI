pub use crate::prelude::*;
use ed_journals::journal::{asynchronous::LiveJournalDirReader, auto_detect_journal_path};
use tokio::sync::mpsc;

pub struct Reader {}

impl Reader {
    pub fn new() -> Self {
        Self {}
    }

    pub async fn read(&self, server: mpsc::Sender<String>) -> Result<()> {
        let journal_directory =
            auto_detect_journal_path().ok_or("Failed to detect journal path")?;
        let mut reader = LiveJournalDirReader::open(journal_directory)?;

        while let Some(event) = reader.next().await {
            if let Ok(event) = event {
                server.send(format!("{:?}", event)).await.unwrap();
            }
        }

        Ok(())
    }
}
