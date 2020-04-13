using System.Text;
using EliteAPI.Events;
using Newtonsoft.Json;

namespace EliteAPI.Status.Ship
{
    public class ShipStatus : EventBase, IStatus
    {
        internal ShipStatus() { }

        [JsonProperty("Flags")]
        public Flags Flags { get; internal set;}

        [JsonProperty("Pips")] 
        private int[] _pips;
        public Pips Pips => new Pips(_pips);

        [JsonProperty("FireGroup")]
        public int FireGroup { get; internal set;}

        [JsonProperty("GuiFocus")]
        public long GuiFocus { get; internal set;}

        [JsonProperty("Fuel")]
        public Fuel Fuel { get; internal set;}

        [JsonProperty("Cargo")]
        public long Cargo { get; internal set;}

        [JsonProperty("LegalState")]
        public string LegalState { get; internal set;}

        [JsonProperty("Latitude")]
        public double Latitude { get; internal set;}

        [JsonProperty("Longitude")]
        public double Longitude { get; internal set;}

        [JsonProperty("Heading")]
        public long Heading { get; internal set;}

        [JsonProperty("Altitude")]
        public long Altitude { get; internal set;}

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
        public bool HasLatlong => GetFlag(21);
        public bool InDanger => GetFlag(22);
        public bool InInterdiction => GetFlag(23);
        public bool InMothership => GetFlag(24);
        public bool InFighter => GetFlag(25);
        public bool InSRV => GetFlag(26);
        public bool AnalysisMode => GetFlag(27);
        public bool NightVision => GetFlag(28);
        public bool AltitudeFromRadius => GetFlag(29);
        public bool FsdJump => GetFlag(30);
        public bool SrvHighBeam => GetFlag(31);

        public GameModeType GameMode { get; internal set; }
        public bool InNoFireZone { get; internal set; }
        public float JumpRange { get; internal set; }
        public bool IsRunning => Flags != 0;
        public bool InMainMenu { get; internal set; }
        public string MusicTrack { get; internal set; }

        private bool GetFlag(int bit)
        {
            return Flags.HasFlag((Flags)(1 << bit));
        }
    }
}
