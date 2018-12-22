using System;
using System.Collections.Generic;

namespace EliteAPI
{
    public class CrewHireInfo
    {
        public DateTime timestamp { get; }
        public String Name { get; }
        public Int64 CrewID { get; }
        public String Faction { get; }
        public Int64 Cost { get; }
        public Int64 CombatRank { get; }
    }
}
