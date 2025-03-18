use crate::events::*;
pub use crate::prelude::*;
use ed_journals::journal::asynchronous::LiveJournalDirReader;
use ed_journals::journal::{auto_detect_journal_path, JournalEvent, JournalEventKind};
use ed_journals::status::{Status, StatusKind};
use tracing::{debug, info};
use tracing::{event, warn};

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
                let json = event.event_json()?;
                let mut variables = json_to_variables_event(event.event_name(), json);

                if let JournalEventKind::StatusEvent(status) = &event.kind {
                    append_status_variables(&mut variables, status)
                };

                match state
                    .server
                    .emit(ServerEvent::VariablesEvent(variables))
                    .await
                {
                    Ok(_) => (),
                    Err(e) => {
                        warn!("Failed to emit variables event: {:?}", e);
                        let _ = state.server.emit(ServerEvent::Error(ErrorEvent(e))).await;
                    }
                }

                match state
                    .server
                    .emit(ServerEvent::JournalEvent(JournalEvent(event.event_name())))
                    .await
                {
                    Ok(_) => (),
                    Err(e) => {
                        warn!("Failed to emit journal event: {:?}", e);
                        let _ = state.server.emit(ServerEvent::Error(ErrorEvent(e))).await;
                    }
                }
            }
        }

        warn!("reader disconnected");

        Ok(())
    }
}

trait Event {
    fn event_name(&self) -> String;
    fn event_json(&self) -> Result<String>;
}

impl Event for ed_journals::journal::JournalEvent {
    fn event_name(&self) -> String {
        match &self.kind {
            JournalEventKind::LogEvent(log_event) => log_event
                .content
                .kind()
                .to_string()
                .split('.')
                .last()
                .unwrap_or_default()
                .to_string(),
            JournalEventKind::StatusEvent(status) => status.event.to_string(),
            JournalEventKind::OutfittingEvent(outfitting) => outfitting.event.to_string(),
            JournalEventKind::ShipyardEvent(shipyard) => shipyard.event.to_string(),
            JournalEventKind::MarketEvent(market) => market.event.to_string(),
            JournalEventKind::NavRoute(nav_route) => nav_route.event.to_string(),
            JournalEventKind::ModulesInfo(modules_info) => modules_info.event.to_string(),
            JournalEventKind::Backpack(backpack) => backpack.event.to_string(),
            JournalEventKind::Cargo(cargo) => cargo.event.to_string(),
            JournalEventKind::ShipLocker(ship_locker) => ship_locker.event.to_string(),
        }
    }

    fn event_json(&self) -> Result<String> {
        let json = match &self.kind {
            JournalEventKind::LogEvent(log_event) => serde_json::to_string(&log_event.content),
            JournalEventKind::StatusEvent(status) => serde_json::to_string(status),
            JournalEventKind::OutfittingEvent(outfitting) => serde_json::to_string(outfitting),
            JournalEventKind::ShipyardEvent(shipyard) => serde_json::to_string(shipyard),
            JournalEventKind::MarketEvent(market) => serde_json::to_string(market),
            JournalEventKind::NavRoute(nav_route) => serde_json::to_string(nav_route),
            JournalEventKind::ModulesInfo(modules_info) => serde_json::to_string(modules_info),
            JournalEventKind::Backpack(backpack) => serde_json::to_string(backpack),
            JournalEventKind::Cargo(cargo) => serde_json::to_string(cargo),
            JournalEventKind::ShipLocker(ship_locker) => serde_json::to_string(ship_locker),
        };

        json.map_err(|e| Error::JournalError(e.to_string()))
    }
}

fn append_status_variables(variables: &mut VariablesEvent, status: &Status) {
    let status = &status.contents;

    let mut set_bool_variables = vec![];
    let mut set_int_variables = vec![];

    set_bool_variables.push(("Available", status.is_some()));

    set_bool_variables.push(("Docked", status.as_ref().is_some_and(|s| s.flags.docked())));
    set_bool_variables.push(("Landed", status.as_ref().is_some_and(|s| s.flags.landed())));
    set_bool_variables.push((
        "Gear",
        status.as_ref().is_some_and(|s| s.flags.landing_gear_down()),
    ));
    set_bool_variables.push((
        "Shields",
        status.as_ref().is_some_and(|s| s.flags.shields_up()),
    ));
    set_bool_variables.push((
        "Supercruise",
        status.as_ref().is_some_and(|s| s.flags.supercruise()),
    ));
    set_bool_variables.push((
        "FlightAssist",
        !status.as_ref().is_some_and(|s| s.flags.flight_assist_off()),
    ));
    set_bool_variables.push((
        "Hardpoints",
        status
            .as_ref()
            .is_some_and(|s| s.flags.hardpoints_deployed()),
    ));
    set_bool_variables.push((
        "Winging",
        status.as_ref().is_some_and(|s| s.flags.in_wing()),
    ));
    set_bool_variables.push((
        "Lights",
        status.as_ref().is_some_and(|s| s.flags.lights_on()),
    ));
    set_bool_variables.push((
        "CargoScoop",
        status
            .as_ref()
            .is_some_and(|s| s.flags.cargo_scoop_deployed()),
    ));
    set_bool_variables.push((
        "SilentRunning",
        status.as_ref().is_some_and(|s| s.flags.silent_running()),
    ));
    set_bool_variables.push((
        "Scooping",
        status.as_ref().is_some_and(|s| s.flags.scooping_fuel()),
    ));
    set_bool_variables.push((
        "SrvHandbrake",
        status.as_ref().is_some_and(|s| s.flags.srv_handbreak()),
    ));
    set_bool_variables.push((
        "SrvTurret",
        status.as_ref().is_some_and(|s| s.flags.srv_turret_view()),
    ));
    set_bool_variables.push((
        "SrvNearShip",
        status
            .as_ref()
            .is_some_and(|s| s.flags.srv_turret_retracted()),
    ));
    set_bool_variables.push((
        "SrvDriveAssist",
        status.as_ref().is_some_and(|s| s.flags.srv_drive_assist()),
    ));
    set_bool_variables.push((
        "MassLocked",
        status.as_ref().is_some_and(|s| s.flags.fsd_masslocked()),
    ));
    set_bool_variables.push((
        "FsdCharging",
        status.as_ref().is_some_and(|s| s.flags.fsd_charging()),
    ));
    set_bool_variables.push((
        "FsdCooldown",
        status.as_ref().is_some_and(|s| s.flags.fsd_cooldown()),
    ));
    set_bool_variables.push((
        "LowFuel",
        status.as_ref().is_some_and(|s| s.flags.low_fuel()),
    ));
    set_bool_variables.push((
        "Overheating",
        status.as_ref().is_some_and(|s| s.flags.overheating()),
    ));
    set_bool_variables.push((
        "HasLatLong",
        status.as_ref().is_some_and(|s| s.flags.has_lat_long()),
    ));
    set_bool_variables.push((
        "InDanger",
        status.as_ref().is_some_and(|s| s.flags.in_danger()),
    ));
    set_bool_variables.push((
        "InInterdiction",
        status.as_ref().is_some_and(|s| s.flags.being_interdicted()),
    ));
    set_bool_variables.push((
        "InMothership",
        status.as_ref().is_some_and(|s| s.flags.in_main_ship()),
    ));
    set_bool_variables.push((
        "InFighter",
        status.as_ref().is_some_and(|s| s.flags.in_fighter()),
    ));
    set_bool_variables.push(("InSrv", status.as_ref().is_some_and(|s| s.flags.in_srv())));
    set_bool_variables.push((
        "AnalysisMode",
        status.as_ref().is_some_and(|s| s.flags.analysis_mode()),
    ));
    set_bool_variables.push((
        "NightVision",
        status.as_ref().is_some_and(|s| s.flags.night_vision()),
    ));
    set_bool_variables.push((
        "AltitudeFromAverageRadius",
        status
            .as_ref()
            .is_some_and(|s| s.flags.altitude_from_average_radius()),
    ));
    set_bool_variables.push((
        "FsdJump",
        status.as_ref().is_some_and(|s| s.flags.fsd_jump()),
    ));
    set_bool_variables.push((
        "SrvHighBeam",
        status.as_ref().is_some_and(|s| s.flags.srv_high_beam()),
    ));

    set_bool_variables.push((
        "OnFoot",
        status.as_ref().is_some_and(|s| s.flags2.on_foot()),
    ));
    set_bool_variables.push((
        "InTaxi",
        status.as_ref().is_some_and(|s| s.flags2.in_taxi()),
    ));
    set_bool_variables.push((
        "InMultiCrew",
        status.as_ref().is_some_and(|s| s.flags2.in_multicrew()),
    ));
    set_bool_variables.push((
        "OnFootInStation",
        status
            .as_ref()
            .is_some_and(|s| s.flags2.on_foot_in_station()),
    ));
    set_bool_variables.push((
        "OnFootOnPlanet",
        status
            .as_ref()
            .is_some_and(|s| s.flags2.on_foot_on_planet()),
    ));
    set_bool_variables.push((
        "AimDownSight",
        status.as_ref().is_some_and(|s| s.flags2.aim_down_sight()),
    ));
    set_bool_variables.push((
        "LowOxygen",
        status.as_ref().is_some_and(|s| s.flags2.low_oxygen()),
    ));
    set_bool_variables.push((
        "LowHealth",
        status.as_ref().is_some_and(|s| s.flags2.low_health()),
    ));
    set_bool_variables.push(("Cold", status.as_ref().is_some_and(|s| s.flags2.cold())));
    set_bool_variables.push(("Hot", status.as_ref().is_some_and(|s| s.flags2.hot())));
    set_bool_variables.push((
        "VeryCold",
        status.as_ref().is_some_and(|s| s.flags2.very_cold()),
    ));
    set_bool_variables.push((
        "VeryHot",
        status.as_ref().is_some_and(|s| s.flags2.very_hot()),
    ));
    set_bool_variables.push((
        "Gliding",
        status.as_ref().is_some_and(|s| s.flags2.glide_mode()),
    ));
    set_bool_variables.push((
        "OnFootInHangar",
        status
            .as_ref()
            .is_some_and(|s| s.flags2.on_foot_in_hangar()),
    ));
    set_bool_variables.push((
        "OnFootInSocialSpace",
        status
            .as_ref()
            .is_some_and(|s| s.flags2.on_foot_social_space()),
    ));
    set_bool_variables.push((
        "OnFootInExterior",
        status.as_ref().is_some_and(|s| s.flags2.on_foot_exterior()),
    ));
    set_bool_variables.push((
        "BreathableAtmosphere",
        status
            .as_ref()
            .is_some_and(|s| s.flags2.breathable_atmosphere()),
    ));
    set_bool_variables.push((
        "TelepresenceMulticrew",
        status
            .as_ref()
            .is_some_and(|s| s.flags2.telepresence_multicrew()),
    ));
    set_bool_variables.push((
        "PhysicalMulticrew",
        status
            .as_ref()
            .is_some_and(|s| s.flags2.physical_multicrew()),
    ));
    set_bool_variables.push((
        "HyperdriveCharging",
        status
            .as_ref()
            .is_some_and(|s| s.flags2.fsd_hyperdrive_charging()),
    ));

    if let Some(status) = status {
        if let StatusKind::Ship(ship_status) = &status.kind {
            set_int_variables.push(("Pips.Weapons", ship_status.weapon_pips()));
            set_int_variables.push(("Pips.Engines", ship_status.engine_pips()));
            set_int_variables.push(("Pips.System", ship_status.system_pips()));
        }
    }

    for (key, value) in set_bool_variables {
        variables.set_variables.push(JsonValuePath::new(
            format!("EliteAPI.{}", key),
            value.to_string(),
            ValueType::Boolean,
        ));
    }
}

fn json_to_variables_event(
    event_name: impl Into<String>,
    json: impl Into<String>,
) -> VariablesEvent {
    let event_name = event_name.into();
    let mut set_paths: Vec<JsonValuePath> = Vec::new();
    let mut unset_paths: Vec<JsonPath> = Vec::new();
    let json = serde_json::from_str(json.into().as_str()).unwrap();

    fn recurse(
        json: &serde_json::Value,
        path: String,
        set_paths: &mut Vec<JsonValuePath>,
        unset_paths: &mut Vec<JsonPath>,
    ) {
        match json {
            serde_json::Value::Object(map) => {
                for (key, value) in map {
                    let new_path = format!("{}.{}", path, key);
                    recurse(value, new_path, set_paths, unset_paths);
                }
            }
            serde_json::Value::Array(array) => {
                // Clear all paths that are children of this array
                unset_paths.push(JsonPath {
                    path: path.to_string(),
                });

                // Set the length of the array
                set_paths.push(JsonValuePath {
                    path: format!("{}.Length", path),
                    encoded_value: array.len().to_string(),
                    value_type: ValueType::Int32,
                });

                // Set the values of the array
                for (i, value) in array.iter().enumerate() {
                    let new_path = format!("{}[{}]", path, i);
                    recurse(value, new_path, set_paths, unset_paths);
                }
            }
            json_value => {
                set_paths.push(JsonValuePath {
                    path: path.to_string(),
                    encoded_value: json.to_string(),
                    value_type: match json_value {
                        serde_json::Value::String(_) => ValueType::String,
                        serde_json::Value::Number(_) => match json_value.as_i64() {
                            Some(_) => ValueType::Int32,
                            None => ValueType::Single,
                        },
                        serde_json::Value::Bool(_) => ValueType::Boolean,
                        _ => ValueType::String,
                    },
                });
            }
        }
    }

    recurse(
        &json,
        format!("EliteAPI.{}", event_name),
        &mut set_paths,
        &mut unset_paths,
    );

    // replace 'EliteAPI.Status.' with 'EliteAPI.'
    for path in set_paths.iter_mut() {
        path.path = path.path.replace("EliteAPI.Status.", "EliteAPI.");
    }

    for path in unset_paths.iter_mut() {
        path.path = path.path.replace("EliteAPI.Status", "EliteAPI");
    }

    VariablesEvent {
        event: event_name,
        set_variables: set_paths,
        unset_variables: unset_paths,
    }
}

#[test]
fn test_json_to_paths() {
    let json = r#"
    {
        "a": {
            "b": {
                "c": 1,
                "d": 2.0
            },
            "e": true
        },
        "f": [
            1,
            2,
            3
        ]
    }
    "#;

    let paths = json_to_variables_event("test_event", json);

    println!("{:?}", paths);

    let expected_paths = vec![
        JsonValuePath::new("EliteAPI.test_event.a.b.c", "1", ValueType::Int32),
        JsonValuePath::new("EliteAPI.test_event.a.b.d", "2.0", ValueType::Single),
        JsonValuePath::new("EliteAPI.test_event.a.e", "true", ValueType::Boolean),
        JsonValuePath::new("EliteAPI.test_event.f[0]", "1", ValueType::Int32),
        JsonValuePath::new("EliteAPI.test_event.f[1]", "2", ValueType::Int32),
        JsonValuePath::new("EliteAPI.test_event.f[2]", "3", ValueType::Int32),
    ];

    let expected_unset_paths = vec![JsonPath::new("EliteAPI.test_event.f")];

    // Check that the paths exists, order doesn't matter
    for expected_path in expected_paths {
        assert!(
            paths
                .set_variables
                .iter()
                .any(|path| path.path == expected_path.path),
            "Expected path not found: {:?}",
            expected_path
        );

        // Check that the values are equal
        let found_path = paths
            .set_variables
            .iter()
            .find(|path| path.path == expected_path.path)
            .unwrap();

        assert_eq!(
            found_path.encoded_value, expected_path.encoded_value,
            "Expected value not found: {:?}",
            expected_path
        );

        assert_eq!(
            found_path.value_type, expected_path.value_type,
            "Expected value type not found: {:?}",
            expected_path
        );
    }

    // Check that the unset paths exists, order doesn't matter
    for expected_path in expected_unset_paths {
        assert!(
            paths
                .unset_variables
                .iter()
                .any(|path| path.path == expected_path.path),
            "Expected unset path not found: {:?}",
            expected_path
        );
    }
}

#[derive(Debug, Clone, serde::Serialize, specta::Type)]
pub struct JsonValuePath {
    path: String,
    encoded_value: String,
    value_type: ValueType,
}

#[derive(Debug, Clone, serde::Serialize, specta::Type)]
pub struct JsonPath {
    path: String,
}

impl JsonPath {
    fn new(path: impl Into<String>) -> Self {
        Self { path: path.into() }
    }
}

impl JsonValuePath {
    fn new(
        path: impl Into<String>,
        encoded_value: impl Into<String>,
        value_type: ValueType,
    ) -> Self {
        Self {
            path: path.into(),
            encoded_value: encoded_value.into(),
            value_type,
        }
    }
}

#[derive(Debug, Clone, serde::Serialize, specta::Type, PartialEq, Eq)]
enum ValueType {
    String,
    Int32,
    Single,
    Boolean,
    DateTime,
}
