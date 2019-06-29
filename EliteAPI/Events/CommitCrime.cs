using System;

namespace EliteAPI
{
    public class CommitCrimeInfo
    {
        public DateTime timestamp { get; set; }
        public string CrimeType { get; set; }
        public string Faction { get; set; }
        public int Fine { get; set; }
    }
}
