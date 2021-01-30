using EliteAPI.Status.Abstractions;

namespace EliteAPI.Status.Ship.Abstractions
{
    /// <summary>
    /// Holds all information about the ship
    /// </summary>
    public interface IShip : IStatus
    {
        /// <summary>
        /// Overview of all ship flags
        /// </summary>
        StatusProperty<ShipFlag> Flags { get; }

        /// <summary>
        /// Whether ship information is currently available
        /// </summary>
        StatusProperty<bool> Available { get; }

        /// <summary>
        /// Whether the ship is currently docked at a station or outpost
        /// </summary>
        StatusProperty<bool> Docked { get; }

        /// <summary>
        /// Whether the ship is currently landed on a planet
        /// </summary>
        StatusProperty<bool> Landed { get; }

        /// <summary>
        /// Whether the ship's landing gear is currently deployed
        /// </summary>
        StatusProperty<bool> Gear { get; }

        /// <summary>
        /// Whether the ship's shields are currently active
        /// </summary>
        StatusProperty<bool> Shields { get; }

        /// <summary>
        /// Whether the ship is currently in supercruise
        /// </summary>
        StatusProperty<bool> Supercruise { get; }

        /// <summary>
        /// Whether the ship's flight assist is enabled
        /// </summary>
        StatusProperty<bool> FlightAssist { get; }

        /// <summary>
        /// Whether the ship's weapons are currently deployed
        /// </summary>
        StatusProperty<bool> Hardpoints { get; }

        /// <summary>
        /// Whether the ship is currently winging with other commanders
        /// </summary>
        StatusProperty<bool> Winging { get; }

        /// <summary>
        /// Whether the ship's exterior lights are currently enabled
        /// </summary>
        StatusProperty<bool> Lights { get; }

        /// <summary>
        /// Whether the ship's cargo scoop is currently deployed
        /// </summary>
        StatusProperty<bool> CargoScoop { get; }

        /// <summary>
        /// Whether the ship is currently in silent running mode
        /// </summary>
        StatusProperty<bool> SilentRunning { get; }

        /// <summary>
        /// Whether the ship is currently scooping fuel from a star
        /// </summary>
        StatusProperty<bool> Scooping { get; }

        /// <summary>
        /// Whether the SRV handbreak is currently enabled
        /// </summary>
        StatusProperty<bool> SrvHandbreak { get; }

        /// <summary>
        /// Whether the SRV turrent is currently enabled
        /// </summary>
        StatusProperty<bool> SrvTurrent { get; }

        /// <summary>
        /// Whether the SRV is currently near the mothership
        /// </summary>
        StatusProperty<bool> SrvNearShip { get; }

        /// <summary>
        /// Whether the SRV has drive assist currently enabled
        /// </summary>
        StatusProperty<bool> SrvDriveAssist { get; }

        /// <summary>
        /// Whether the ship is currently mass locked
        /// </summary>
        StatusProperty<bool> MassLocked { get; }

        /// <summary>
        /// Whether the ship's frame shift drive is currently charging
        /// </summary>
        StatusProperty<bool> FsdCharging { get; }

        /// <summary>
        /// Whether the ship's frame shift drive is currently cooling down
        /// </summary>
        StatusProperty<bool> FsdCooldown { get; }

        /// <summary>
        /// Whether the ship is currently low on fuel
        /// </summary>
        StatusProperty<bool> LowFuel { get; }

        /// <summary>
        /// Whether the ship is currently overheating
        /// </summary>
        StatusProperty<bool> Overheating { get; }

        /// <summary>
        /// Whether the ship currently has latitude and longitude information available
        /// </summary>
        StatusProperty<bool> HasLatLong { get; }

        /// <summary>
        /// Whether the ship is currently in danger
        /// </summary>
        StatusProperty<bool> InDanger { get; }

        /// <summary>
        /// Whether the ship is currently being interdicted
        /// </summary>
        StatusProperty<bool> InInterdiction { get; }

        /// <summary>
        /// Whether the ship's commander is currently in the mothership
        /// </summary>
        StatusProperty<bool> InMothership { get; }

        /// <summary>
        /// Whether the ship's commander is currently in the fighter
        /// </summary>
        StatusProperty<bool> InFighter { get; }

        /// <summary>
        /// Whether the ship's commander is currently in the SRV
        /// </summary>
        StatusProperty<bool> InSrv { get; }

        /// <summary>
        /// Whether the ship is currently in analysis mode
        /// </summary>
        StatusProperty<bool> AnalysisMode { get; }

        /// <summary>
        /// Whether the ship currently has night vision enabled
        /// </summary>
        StatusProperty<bool> NightVision { get; }

        /// <summary>
        /// Whether the ship's current altitude is being calculated by the planet's average radius
        /// See also <see cref="Altitude" />
        /// </summary>
        StatusProperty<bool> AltitudeFromAverageRadius { get; }

        /// <summary>
        /// Whether the ship is currently in a jump to another star system
        /// </summary>
        StatusProperty<bool> FsdJump { get; }

        /// <summary>
        /// Whether the ship's SRV high beam is currently active
        /// </summary>
        StatusProperty<bool> SrvHighBeam { get; }

        /// <summary>
        /// The ship's currently energy distribution configuration
        /// </summary>
        StatusProperty<ShipPips> Pips { get; }

        /// <summary>
        /// The ship's current firegroup
        /// </summary>
        StatusProperty<int> FireGroup { get; }

        /// <summary>
        /// The ship's current interface focus
        /// </summary>
        StatusProperty<ShipGuiFocus> GuiFocus { get; }

        /// <summary>
        /// The ship's current fuel information
        /// </summary>
        StatusProperty<ShipFuel> Fuel { get; }

        /// <summary>
        /// The ship's currently amount of cargo in tonnes
        /// </summary>
        StatusProperty<int> Cargo { get; }

        /// <summary>
        /// The ship's current legal state
        /// </summary>
        StatusProperty<ShipLegalState> LegalState { get; }

        /// <summary>
        /// The ship's current latitude on the planet
        /// </summary>
        StatusProperty<float> Latitude { get; }

        /// <summary>
        /// The ship's current altitude on the planet
        /// </summary>
        StatusProperty<float> Altitude { get; }

        /// <summary>
        /// The ship's current longitude on the planet
        /// </summary>
        StatusProperty<float> Longitude { get; }

        /// <summary>
        /// The ship's current heading on the planet
        /// </summary>
        StatusProperty<float> Heading { get; }

        /// <summary>
        /// The name of the body the ship is currently visiting
        /// </summary>
        StatusProperty<string> Body { get; }

        /// <summary>
        /// The radius of the currently visiting body
        /// </summary>
        StatusProperty<float> BodyRadius { get; }
    }
}