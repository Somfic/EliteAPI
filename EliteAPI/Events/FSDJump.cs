using System;
using System.Collections.Generic;

namespace EliteAPI
{
    public class FSDJumpInfo
    {
        public DateTime timestamp { get; }
        public string StarSystem { get; }
        public long SystemAddress { get; }
        public List<double> StarPos { get; }
        public string SystemAllegiance { get; }
        public string SystemEconomy { get; }
        public string SystemEconomy_Localised { get; }
        public string SystemSecondEconomy { get; }
        public string SystemSecondEconomy_Localised { get; }
        public string SystemGovernment { get; }
        public string SystemGovernment_Localised { get; }
        public string SystemSecurity { get; }
        public string SystemSecurity_Localised { get; }
        public ulong Population { get; }
        public double JumpDist { get; }
        public double FuelUsed { get; }
        public double FuelLevel { get; }
    }
}
