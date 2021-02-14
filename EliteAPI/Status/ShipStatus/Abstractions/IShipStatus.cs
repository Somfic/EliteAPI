using System;

using EliteAPI.Status.Abstractions;
using EliteAPI.Status.Ship;

namespace EliteAPI.Status.Models.Abstractions
{
    [Obsolete("Use IShip instead", true)]
    public interface IShipStatus : IStatus
    {
        StatusProperty<ShipFlag> Flags { get; }
        StatusProperty<bool> Available { get; }
        StatusProperty<bool> Docked { get; }
        StatusProperty<bool> Landed { get; }
        StatusProperty<bool> Gear { get; }
        StatusProperty<bool> Shields { get; }
        StatusProperty<bool> Supercruise { get; }
        StatusProperty<bool> FlightAssist { get; }
        StatusProperty<bool> Hardpoints { get; }
        StatusProperty<bool> Winging { get; }
        StatusProperty<bool> Lights { get; }
        StatusProperty<bool> CargoScoop { get; }
        StatusProperty<bool> SilentRunning { get; }
        StatusProperty<bool> Scooping { get; }
        StatusProperty<bool> SrvHandbreak { get; }
        StatusProperty<bool> SrvTurrent { get; }
        StatusProperty<bool> SrvNearShip { get; }
        StatusProperty<bool> SrvDriveAssist { get; }
        StatusProperty<bool> MassLocked { get; }
        StatusProperty<bool> FsdCharging { get; }
        StatusProperty<bool> FsdCooldown { get; }
        StatusProperty<bool> LowFuel { get; }
        StatusProperty<bool> Overheating { get; }
        StatusProperty<bool> HasLatLong { get; }
        StatusProperty<bool> InDanger { get; }
        StatusProperty<bool> InInterdiction { get; }
        StatusProperty<bool> InMothership { get; }
        StatusProperty<bool> InFighter { get; }
        StatusProperty<bool> InSrv { get; }
        StatusProperty<bool> AnalysisMode { get; }
        StatusProperty<bool> NightVision { get; }
        StatusProperty<bool> AltitudeFromAverageRadius { get; }
        StatusProperty<bool> FsdJump { get; }
        StatusProperty<bool> SrvHighBeam { get; }
        StatusProperty<ShipPips> Pips { get; }
        StatusProperty<int> FireGroup { get; }
        StatusProperty<ShipGuiFocus> GuiFocus { get; }
        StatusProperty<ShipFuel> Fuel { get; }
        StatusProperty<int> Cargo { get; }
        StatusProperty<ShipLegalState> LegalState { get; }
        StatusProperty<float> Latitude { get; }
        StatusProperty<float> Altitude { get; }
        StatusProperty<float> Longitude { get; }
        StatusProperty<float> Heading { get; }
        StatusProperty<string> Body { get; }
        StatusProperty<float> BodyRadius { get; }
    }
}