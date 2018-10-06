using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteAPI
{
    public class ShipTargeted
    {
        public DateTime timestamp { get; set; }
        public string @event { get; set; }
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
        public int Bounty { get; set; }
    }
}
