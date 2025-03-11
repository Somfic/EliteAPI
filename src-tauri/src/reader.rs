pub use crate::prelude::*;
use ed_journals::{
    journal::{asynchronous::LiveJournalDirReader, auto_detect_journal_path},
    logs::{LogDir, LogFile},
};
use tokio::{sync::broadcast, time::sleep};

pub struct Reader {
    pub sender: broadcast::Sender<String>,
}

impl Reader {
    pub fn new() -> Self {
        let (sender, _) = broadcast::channel(100);

        Reader { sender }
    }

    pub async fn read(&self) -> Result<()> {
        let journal_directory =
            auto_detect_journal_path().ok_or("Failed to detect journal path")?;
        let mut reader = LiveJournalDirReader::open(journal_directory)?;

        while let Some(event) = reader.next().await {
            if let Ok(event) = event {
                self.sender.send(format!("{:?}", event));
            }
        }

        Ok(())
    }
}
