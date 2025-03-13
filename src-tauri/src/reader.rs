pub use crate::prelude::*;
use crate::{server::ServerEvent, Server};
use ed_journals::journal::{asynchronous::LiveJournalDirReader, auto_detect_journal_path};

pub struct Reader {}

impl Reader {
    pub fn new() -> Self {
        Self {}
    }

    pub async fn read(&self, state: &AppState) -> Result<()> {
        let journal_directory =
            auto_detect_journal_path().ok_or("Failed to detect journal path")?;
        let mut reader = LiveJournalDirReader::open(&journal_directory)?;

        println!("Reading journal events from: {:?}", journal_directory);

        while let Some(event) = reader.next().await {
            if let Ok(event) = event {
                //println!("Journal event: {:?}", event);

                state
                    .server
                    .emit(ServerEvent::JournalEvent(event))
                    .await
                    .unwrap();
            }
        }

        println!("Reader disconnected");

        Ok(())
    }
}
