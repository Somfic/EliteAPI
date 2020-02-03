using System; 

using System.Collections.Generic;

namespace EliteAPI
{
    public class CrewHireInfo
    {
        public DateTime timestamp { get; set; }
        public String Name { get; set; }
        public Int64 CrewID { get; set; }
        public String Faction { get; set; }
        public Int64 Cost { get; set; }
        public Int64 CombatRank { get; set; }
    }
}
