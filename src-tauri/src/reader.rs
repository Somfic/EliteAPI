pub use crate::prelude::*;
use crate::{server::ServerEvent, Server};
use ed_journals::journal::{asynchronous::LiveJournalDirReader, auto_detect_journal_path};
use tracing::{debug, info, instrument, trace};

pub struct Reader {}

impl Reader {
    pub fn new() -> Self {
        Self {}
    }

    pub async fn read(&self, state: &AppState) -> Result<()> {
        info!("looking for journal files");
        let journal_directory = auto_detect_journal_path().ok_or(Error::JournalPathNotFound)?;
        let mut reader = LiveJournalDirReader::open(&journal_directory)
            .map_err(|e| Error::JournalError(e.to_string()))?;

        debug!("journal directory: {:?}", journal_directory);

        while let Some(event) = reader.next().await {
            if let Ok(event) = event {
                state.server.emit(ServerEvent::JournalEvent(event)).await?;
            }
        }

        warn!("reader disconnected");

        Ok(())
    }
}
