use crate::prelude::*;
use crate::reader::JsonPath;

#[derive(Debug, Clone, serde::Serialize)]
pub enum ServerEvent {
    Log(LogEvent),
    Error(ErrorEvent),
    JournalEvent(JournalEvent),
    VariablesEvent(VariablesEvent),
}

#[derive(Debug, Clone, serde::Serialize)]
enum EventKind {
    LogEvent,
    ErrorEvent,
    JournalEvent,
    VariablesEvent,
}

#[derive(Debug, Clone, serde::Serialize)]
pub struct IpcEvent {
    pub event: ServerEvent,
    pub kind: EventKind,
}

#[derive(Debug, Clone, serde::Serialize, tauri_specta::Event, specta::Type)]
pub struct LogEvent(pub String);

#[derive(Debug, Clone, serde::Serialize, tauri_specta::Event, specta::Type)]
pub struct ErrorEvent(pub crate::Error);

#[derive(Debug, Clone, serde::Serialize, tauri_specta::Event, specta::Type)]
pub struct JournalEvent(pub String);

#[derive(Debug, Clone, serde::Serialize, tauri_specta::Event, specta::Type)]
pub struct VariablesEvent {
    pub event: String,
    pub variables: Vec<JsonPath>,
}

impl ServerEvent {
    pub fn to_json(&self) -> Result<String> {
        // TODO: fix this mess

        let event = IpcEvent {
            event: self.clone(),
            kind: match self {
                ServerEvent::Log(_) => EventKind::LogEvent,
                ServerEvent::Error(_) => EventKind::ErrorEvent,
                ServerEvent::JournalEvent(_) => EventKind::JournalEvent,
                ServerEvent::VariablesEvent(_) => EventKind::VariablesEvent,
            },
        };

        serde_json::to_string(&event).map_err(|e| Error::JsonError(e.to_string()))

        // match self {
        //     ServerEvent::Log(log) => serde_json::to_string(&log.0),
        //     ServerEvent::Error(error) => serde_json::to_string(&error.0),
        //     ServerEvent::JournalEvent(journal_event) => serde_json::to_string(&journal_event.0),
        //     ServerEvent::VariablesEvent(variables_event) => serde_json::to_string(variables_event),
        // }
        // .map_err(|e| Error::JsonError(e.to_string()))
    }
}
