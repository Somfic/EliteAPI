using System;
using System.Collections.Generic;

namespace EliteAPI
{
    public class FSDJumpInfo
    {
        public DateTime timestamp { get; set; }
        public string StarSystem { get; set; }
        public long SystemAddress { get; set; }
        public List<double> StarPos { get; set; }
        public string SystemAllegiance { get; set; }
        public string SystemEconomy { get; set; }
        public string SystemEconomy_Localised { get; set; }
        public string SystemSecondEconomy { get; set; }
        public string SystemSecondEconomy_Localised { get; set; }
        public string SystemGovernment { get; set; }
        public string SystemGovernment_Localised { get; set; }
        public string SystemSecurity { get; set; }
        public string SystemSecurity_Localised { get; set; }
        public ulong Population { get; set; }
        public double JumpDist { get; set; }
        public double FuelUsed { get; set; }
        public double FuelLevel { get; set; }
    }
}
