using System;

namespace EliteAPI
{
    public class NpcCrewPaidWageInfo
    {
        public DateTime timestamp { get; set; }
        public string NpcCrewName { get; set; }
        public int NpcCrewId { get; set; }
        public int Amount { get; set; }
    }
}
