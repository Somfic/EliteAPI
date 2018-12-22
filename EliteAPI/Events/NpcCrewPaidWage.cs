using System;

namespace EliteAPI
{
    public class NpcCrewPaidWageInfo
    {
        public DateTime timestamp { get; }
        public string NpcCrewName { get; }
        public int NpcCrewId { get; }
        public int Amount { get; }
    }
}
