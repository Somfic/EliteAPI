using EliteAPI.Status.Models.Abstractions;

namespace EliteAPI.Status.Models
{
    public class ShipStatus : IShipStatus
    {
        public ShipStatusProperty<ShipStatusFlags> Flags { get; } =
            new ShipStatusProperty<ShipStatusFlags>(ShipStatusFlags.None);

        public ShipStatusProperty<bool> Docked { get; } = new ShipStatusProperty<bool>(false);
        public ShipStatusProperty<bool> Landed { get; } = new ShipStatusProperty<bool>(false);
        public ShipStatusProperty<bool> Gear { get; } = new ShipStatusProperty<bool>(false);
        public ShipStatusProperty<bool> Shields { get; } = new ShipStatusProperty<bool>(false);
        public ShipStatusProperty<bool> Supercruise { get; } = new ShipStatusProperty<bool>(false);
        public ShipStatusProperty<bool> FlightAssist { get; } = new ShipStatusProperty<bool>(false);
        public ShipStatusProperty<bool> Hardpoints { get; } = new ShipStatusProperty<bool>(false);
        public ShipStatusProperty<bool> Winging { get; } = new ShipStatusProperty<bool>(false);
        public ShipStatusProperty<bool> Lights { get; } = new ShipStatusProperty<bool>(false);
        public ShipStatusProperty<bool> CargoScoop { get; } = new ShipStatusProperty<bool>(false);
        public ShipStatusProperty<bool> SilentRunning { get; } = new ShipStatusProperty<bool>(false);
        public ShipStatusProperty<bool> Scooping { get; } = new ShipStatusProperty<bool>(false);
        public ShipStatusProperty<bool> SrvHandbreak { get; } = new ShipStatusProperty<bool>(false);
        public ShipStatusProperty<bool> SrvTurrent { get; } = new ShipStatusProperty<bool>(false);
        public ShipStatusProperty<bool> SrvNearShip { get; } = new ShipStatusProperty<bool>(false);
        public ShipStatusProperty<bool> SrvDriveAssist { get; } = new ShipStatusProperty<bool>(false);
        public ShipStatusProperty<bool> MassLocked { get; } = new ShipStatusProperty<bool>(false);
        public ShipStatusProperty<bool> FsdCharging { get; } = new ShipStatusProperty<bool>(false);
        public ShipStatusProperty<bool> FsdCooldown { get; } = new ShipStatusProperty<bool>(false);
        public ShipStatusProperty<bool> LowFuel { get; } = new ShipStatusProperty<bool>(false);
        public ShipStatusProperty<bool> Overheating { get; } = new ShipStatusProperty<bool>(false);
        public ShipStatusProperty<bool> HasLatLong { get; } = new ShipStatusProperty<bool>(false);
        public ShipStatusProperty<bool> InDanger { get; } = new ShipStatusProperty<bool>(false);
        public ShipStatusProperty<bool> InInterdiction { get; } = new ShipStatusProperty<bool>(false);
        public ShipStatusProperty<bool> InMothership { get; } = new ShipStatusProperty<bool>(false);
        public ShipStatusProperty<bool> InFighter { get; } = new ShipStatusProperty<bool>(false);
        public ShipStatusProperty<bool> InSrv { get; } = new ShipStatusProperty<bool>(false);
        public ShipStatusProperty<bool> AnalysisMode { get; } = new ShipStatusProperty<bool>(false);
        public ShipStatusProperty<bool> NightVision { get; } = new ShipStatusProperty<bool>(false);
        public ShipStatusProperty<bool> AltitudeFromAverageRadius { get; } = new ShipStatusProperty<bool>(false);
        public ShipStatusProperty<bool> FsdJump { get; } = new ShipStatusProperty<bool>(false);
        public ShipStatusProperty<bool> SrvHighBeam { get; } = new ShipStatusProperty<bool>(false);

        public ShipStatusProperty<ShipPips> Pips { get; } =
            new ShipStatusProperty<ShipPips>(new ShipPips(new[] {0, 0, 0}));

        public ShipStatusProperty<int> FireGroup { get; } = new ShipStatusProperty<int>(0);

        public ShipStatusProperty<ShipGuiFocus> GuiFocus { get; } =
            new ShipStatusProperty<ShipGuiFocus>(ShipGuiFocus.NoFocus);

        public ShipStatusProperty<ShipFuel> Fuel { get; } = new ShipStatusProperty<ShipFuel>(new ShipFuel());
        public ShipStatusProperty<float> Cargo { get; } = new ShipStatusProperty<float>(0);

        public ShipStatusProperty<ShipLegalState> LegalState { get; } =
            new ShipStatusProperty<ShipLegalState>(ShipLegalState.Clean);

        public ShipStatusProperty<float> Latitude { get; } = new ShipStatusProperty<float>(0);
        public ShipStatusProperty<float> Altitude { get; } = new ShipStatusProperty<float>(0);
        public ShipStatusProperty<float> Longitude { get; } = new ShipStatusProperty<float>(0);
        public ShipStatusProperty<float> Heading { get; } = new ShipStatusProperty<float>(0);
        public ShipStatusProperty<string> Body { get; } = new ShipStatusProperty<string>(string.Empty);
        public ShipStatusProperty<float> BodyRadius { get; } = new ShipStatusProperty<float>(0);

        public event EventHandler OnChange;

        void IShipStatus.TriggerOnChange()
        {
            OnChange?.Invoke(this, EventArgs.Empty);
        }
    }
}