using System;

namespace EliteAPI
{
    public class InterdictionInfo
    {
        public DateTime timestamp { get; set; }
        public bool Success { get; set; }
        public string Interdicted { get; set; }
        public bool IsPlayer { get; set; }
        public int CombatRank { get; set; }
    }
}
