using System;

namespace EliteAPI
{
    public class CommitCrimeInfo
    {
        public DateTime timestamp { get; }
        public string CrimeType { get; }
        public string Faction { get; }
        public int Fine { get; }
    }
}
