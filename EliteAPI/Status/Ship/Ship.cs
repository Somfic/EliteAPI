using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using EliteAPI.Status.Abstractions;
using EliteAPI.Status.Ship.Abstractions;

namespace EliteAPI.Status.Ship
{
    /// <inheritdoc />
    public class Ship : IShip
    {
        /// <inheritdoc />
        public StatusProperty<ShipFlag> Flags { get; } = new(ShipFlag.None);

        /// <inheritdoc />
        public StatusProperty<bool> Available { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> Docked { get; } = new(false);

        /// <inheritdoc />
        public StatusProperty<bool> Landed { get; } = new(false);

        /// <inheritdoc />
        public StatusProperty<bool> Gear { get; } = new(false);

        /// <inheritdoc />
        public StatusProperty<bool> Shields { get; } = new(false);

        /// <inheritdoc />
        public StatusProperty<bool> Supercruise { get; } = new(false);
        /// <inheritdoc />
        public StatusProperty<bool> FlightAssist { get; } = new(false);

        /// <inheritdoc />
        public StatusProperty<bool> Hardpoints { get; } = new(false);

        /// <inheritdoc />
        public StatusProperty<bool> Winging { get; } = new(false);

        /// <inheritdoc />
        public StatusProperty<bool> Lights { get; } = new(false);

        /// <inheritdoc />
        public StatusProperty<bool> CargoScoop { get; } = new(false);

        /// <inheritdoc />
        public StatusProperty<bool> SilentRunning { get; } = new(false);

        /// <inheritdoc />
        public StatusProperty<bool> Scooping { get; } = new(false);

        /// <inheritdoc />
        public StatusProperty<bool> SrvHandbreak { get; } = new(false);

        /// <inheritdoc />
        public StatusProperty<bool> SrvTurrent { get; } = new(false);

        /// <inheritdoc />
        public StatusProperty<bool> SrvNearShip { get; } = new(false);

        /// <inheritdoc />
        public StatusProperty<bool> SrvDriveAssist { get; } = new(false);

        /// <inheritdoc />
        public StatusProperty<bool> MassLocked { get; } = new(false);

        /// <inheritdoc />
        public StatusProperty<bool> FsdCharging { get; } = new(false);

        /// <inheritdoc />
        public StatusProperty<bool> FsdCooldown { get; } = new(false);

        /// <inheritdoc />
        public StatusProperty<bool> LowFuel { get; } = new(false);

        /// <inheritdoc />
        public StatusProperty<bool> Overheating { get; } = new(false);

        /// <inheritdoc />
        public StatusProperty<bool> HasLatLong { get; } = new(false);

        /// <inheritdoc />
        public StatusProperty<bool> InDanger { get; } = new(false);

        /// <inheritdoc />
        public StatusProperty<bool> InInterdiction { get; } = new(false);

        /// <inheritdoc />
        public StatusProperty<bool> InMothership { get; } = new(false);

        /// <inheritdoc />
        public StatusProperty<bool> InFighter { get; } = new(false);

        /// <inheritdoc />
        public StatusProperty<bool> InSrv { get; } = new(false);

        /// <inheritdoc />
        public StatusProperty<bool> AnalysisMode { get; } = new(false);

        /// <inheritdoc />
        public StatusProperty<bool> NightVision { get; } = new(false);

        /// <inheritdoc />
        public StatusProperty<bool> AltitudeFromAverageRadius { get; } = new(false);

        /// <inheritdoc />
        public StatusProperty<bool> FsdJump { get; } = new(false);

        /// <inheritdoc />
        public StatusProperty<bool> SrvHighBeam { get; } = new(false);

        /// <inheritdoc />
        public StatusProperty<ShipPips> Pips { get; } = new(new ShipPips(new[] {0, 0, 0}));

        /// <inheritdoc />
        public StatusProperty<int> FireGroup { get; } = new(0);

        /// <inheritdoc />
        public StatusProperty<ShipGuiFocus> GuiFocus { get; } = new(ShipGuiFocus.NoFocus);

        /// <inheritdoc />
        public StatusProperty<ShipFuel> Fuel { get; } = new(new ShipFuel());

        /// <inheritdoc />
        public StatusProperty<int> Cargo { get; } = new(0);

        /// <inheritdoc />
        public StatusProperty<ShipLegalState> LegalState { get; } = new(ShipLegalState.Clean);

        /// <inheritdoc />
        public StatusProperty<float> Latitude { get; } = new(0);

        /// <inheritdoc />
        public StatusProperty<float> Altitude { get; } = new(0);

        /// <inheritdoc />
        public StatusProperty<float> Longitude { get; } = new(0);

        /// <inheritdoc />
        public StatusProperty<float> Heading { get; } = new(0);

        /// <inheritdoc />
        public StatusProperty<string> Body { get; } = new(string.Empty);

        /// <inheritdoc />
        public StatusProperty<float> BodyRadius { get; } = new(0);

        /// <inheritdoc />
        public event EventHandler OnChange;

        void IStatus.TriggerOnChange()
        {
            OnChange?.Invoke(this, EventArgs.Empty);
        }
    }
}