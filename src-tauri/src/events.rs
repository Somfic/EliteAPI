use crate::prelude::*;
use crate::reader::{JsonPath, JsonValuePath};

#[derive(Debug, Clone, serde::Serialize)]
pub enum ServerEvent {
    Log(LogEvent),
    Error(ErrorEvent),
    JournalEvent(JournalEvent),
    VariablesEvent(VariablesEvent),
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
    pub set_variables: Vec<JsonValuePath>,
    pub unset_variables: Vec<JsonPath>,
}
