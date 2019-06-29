using System;

namespace EliteAPI
{
    public class ShipTargetedInfo
    {
        public DateTime timestamp { get; set; }
        public bool TargetLocked { get; set; }
        public string Ship { get; set; }
        public string Ship_Localised { get; set; }
        public int ScanStage { get; set; }
        public string PilotName { get; set; }
        public string PilotName_Localised { get; set; }
        public string PilotRank { get; set; }
        public double ShieldHealth { get; set; }
        public double HullHealth { get; set; }
        public string Faction { get; set; }
        public string LegalStatus { get; set; }
        public bool IsWanted { get { return !Equals(LegalStatus, "Clean"); } }
        public int Bounty { get; set; }
    }
}
