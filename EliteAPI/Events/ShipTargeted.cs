using System;

namespace EliteAPI
{
    public class ShipTargetedInfo
    {
        public DateTime timestamp { get; }
        public bool TargetLocked { get; }
        public string Ship { get; }
        public string Ship_Localised { get; }
        public int ScanStage { get; }
        public string PilotName { get; }
        public string PilotName_Localised { get; }
        public string PilotRank { get; }
        public double ShieldHealth { get; }
        public double HullHealth { get; }
        public string Faction { get; }
        public string LegalStatus { get; }
        public bool IsWanted { get { return !Equals(LegalStatus, "Clean"); } }
        public int Bounty { get; }
    }
}
