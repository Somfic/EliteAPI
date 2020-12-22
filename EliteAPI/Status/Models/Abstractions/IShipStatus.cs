namespace EliteAPI.Status.Models.Abstractions
{
    public interface IShipStatus
    {
        ShipStatusProperty<ShipStatusFlags> Flags { get; }
        ShipStatusProperty<bool> Docked { get; }
        ShipStatusProperty<bool> Landed { get; }
        ShipStatusProperty<bool> Gear { get; }
        ShipStatusProperty<bool> Shields { get; }
        ShipStatusProperty<bool> Supercruise { get; }
        ShipStatusProperty<bool> FlightAssist { get; }
        ShipStatusProperty<bool> Hardpoints { get; }
        ShipStatusProperty<bool> Winging { get; }
        ShipStatusProperty<bool> Lights { get; }
        ShipStatusProperty<bool> CargoScoop { get; }
        ShipStatusProperty<bool> SilentRunning { get; }
        ShipStatusProperty<bool> Scooping { get; }
        ShipStatusProperty<bool> SrvHandbreak { get; }
        ShipStatusProperty<bool> SrvTurrent { get; }
        ShipStatusProperty<bool> SrvNearShip { get; }
        ShipStatusProperty<bool> SrvDriveAssist { get; }
        ShipStatusProperty<bool> MassLocked { get; }
        ShipStatusProperty<bool> FsdCharging { get; }
        ShipStatusProperty<bool> FsdCooldown { get; }
        ShipStatusProperty<bool> LowFuel { get; }
        ShipStatusProperty<bool> Overheating { get; }
        ShipStatusProperty<bool> HasLatLong { get; }
        ShipStatusProperty<bool> InDanger { get; }
        ShipStatusProperty<bool> InInterdiction { get; }
        ShipStatusProperty<bool> InMothership { get; }
        ShipStatusProperty<bool> InFighter { get; }
        ShipStatusProperty<bool> InSrv { get; }
        ShipStatusProperty<bool> AnalysisMode { get; }
        ShipStatusProperty<bool> NightVision { get; }
        ShipStatusProperty<bool> AltitudeFromAverageRadius { get; }
        ShipStatusProperty<bool> FsdJump { get; }
        ShipStatusProperty<bool> SrvHighBeam { get; }
        ShipStatusProperty<ShipPips> Pips { get; }
        ShipStatusProperty<int> FireGroup { get; }
        ShipStatusProperty<ShipGuiFocus> GuiFocus { get; }
        ShipStatusProperty<ShipFuel> Fuel { get; }
        ShipStatusProperty<float> Cargo { get; }
        ShipStatusProperty<ShipLegalState> LegalState { get; }
        ShipStatusProperty<float> Latitude { get; }
        ShipStatusProperty<float> Altitude { get; }
        ShipStatusProperty<float> Longitude { get; }
        ShipStatusProperty<float> Heading { get; }
        ShipStatusProperty<string> Body { get; }
        ShipStatusProperty<float> BodyRadius { get; }

        event EventHandler OnChange;

        internal void TriggerOnChange();
    }
}