using EliteAPI.Status.Ship.JsonConverters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EliteAPI.Status.Ship.Raw
{
    internal class RawShip
    {
        [JsonProperty("Flag")] public ShipFlag Flags { get; private set; }

        public bool Available => Flags != 0;
        public bool Docked => GetFlag(0);
        public bool Landed => GetFlag(1);
        public bool Gear => GetFlag(2);
        public bool Shields => GetFlag(3);
        public bool Supercruise => GetFlag(4);
        public bool FlightAssist => !GetFlag(5);
        public bool Hardpoints => GetFlag(6);
        public bool Winging => GetFlag(7);
        public bool Lights => GetFlag(8);
        public bool CargoScoop => GetFlag(9);
        public bool SilentRunning => GetFlag(10);
        public bool Scooping => GetFlag(11);
        public bool SrvHandbreak => GetFlag(12);
        public bool SrvTurrent => GetFlag(13);
        public bool SrvNearShip => GetFlag(14);
        public bool SrvDriveAssist => GetFlag(15);
        public bool MassLocked => GetFlag(16);
        public bool FsdCharging => GetFlag(17);
        public bool FsdCooldown => GetFlag(18);
        public bool LowFuel => GetFlag(19);
        public bool Overheating => GetFlag(20);
        public bool HasLatLong => GetFlag(21);
        public bool InDanger => GetFlag(22);
        public bool InInterdiction => GetFlag(23);
        public bool InMothership => GetFlag(24);
        public bool InFighter => GetFlag(25);
        public bool InSrv => GetFlag(26);
        public bool AnalysisMode => GetFlag(27);
        public bool NightVision => GetFlag(28);
        public bool AltitudeFromAverageRadius => GetFlag(29);
        public bool FsdJump => GetFlag(30);
        public bool SrvHighBeam => GetFlag(31);

        [JsonProperty("Pips")]
        [JsonConverter(typeof(PipsConverter))]
        public ShipPips Pips { get; private set; }

        [JsonProperty("FireGroup")] public int FireGroup { get; private set; }

        [JsonProperty("GuiFocus")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ShipGuiFocus GuiFocus { get; private set; }

        [JsonProperty("Fuel")] public ShipFuel Fuel { get; private set; }

        [JsonProperty("Cargo")] 
        [JsonConverter(typeof(DecimalToIntConverter))]
        public int Cargo { get; private set; }

        [JsonProperty("LegalState")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ShipLegalState LegalState { get; private set; }

        [JsonProperty("Latitude")] public float Latitude { get; private set; }

        [JsonProperty("Altitude")] public float Altitude { get; private set; }

        [JsonProperty("Longitude")] public float Longitude { get; private set; }

        [JsonProperty("Heading")] public float Heading { get; private set; }

        [JsonProperty("BodyName")] public string Body { get; private set; } = string.Empty;

        [JsonProperty("PlanetRadius")] public float BodyRadius { get; private set; }

        private bool GetFlag(int bit)
        {
            return Flags.HasFlag((ShipFlag)(1 << bit));
        }
    }
}