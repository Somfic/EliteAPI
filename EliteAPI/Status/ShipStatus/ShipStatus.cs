using System;

using EliteAPI.Status.Abstractions;
using EliteAPI.Status.Models.Abstractions;
using EliteAPI.Status.Ship;

namespace EliteAPI.Status.ShipStatus
{
    [Obsolete("Use Ship instead", false)]
    public class ShipStatus : IShipStatus
    {
        /// <inheritdoc />
        public StatusProperty<ShipFlag> Flags { get; } = new(ShipFlag.None);

        /// <inheritdoc />
        public StatusProperty<bool> Available { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> Docked { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> Landed { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> Gear { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> Shields { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> Supercruise { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> FlightAssist { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> Hardpoints { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> Winging { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> Lights { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> CargoScoop { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> SilentRunning { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> Scooping { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> SrvHandbreak { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> SrvTurrent { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> SrvNearShip { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> SrvDriveAssist { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> MassLocked { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> FsdCharging { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> FsdCooldown { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> LowFuel { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> Overheating { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> HasLatLong { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> InDanger { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> InInterdiction { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> InMothership { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> InFighter { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> InSrv { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> AnalysisMode { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> NightVision { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> AltitudeFromAverageRadius { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> FsdJump { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> SrvHighBeam { get; } = new();

        /// <inheritdoc />
        public StatusProperty<ShipPips> Pips { get; } = new();

        /// <inheritdoc />
        public StatusProperty<int> FireGroup { get; } = new();

        /// <inheritdoc />
        public StatusProperty<ShipGuiFocus> GuiFocus { get; } = new();

        /// <inheritdoc />
        public StatusProperty<ShipFuel> Fuel { get; } = new();

        /// <inheritdoc />
        public StatusProperty<int> Cargo { get; } = new();

        /// <inheritdoc />
        public StatusProperty<ShipLegalState> LegalState { get; } = new();

        /// <inheritdoc />
        public StatusProperty<float> Latitude { get; } = new();

        /// <inheritdoc />
        public StatusProperty<float> Altitude { get; } = new();

        /// <inheritdoc />
        public StatusProperty<float> Longitude { get; } = new();

        /// <inheritdoc />
        public StatusProperty<float> Heading { get; } = new();

        /// <inheritdoc />
        public StatusProperty<string> Body { get; } = new();

        /// <inheritdoc />
        public StatusProperty<float> BodyRadius { get; } = new();

        /// <inheritdoc />
        public event EventHandler OnChange;

        /// <inheritdoc />
        void IStatus.TriggerOnChange()
        {
            OnChange?.Invoke(this, EventArgs.Empty);
        }
    }
}