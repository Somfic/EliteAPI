using System;

namespace EliteAPI
{
    public class InterdictedInfo
    {
        public DateTime timestamp { get; }
        public bool Submitted { get; }
        public string Interdictor { get; }
        public bool IsPlayer { get; }
        public string Faction { get; }
    }
}
