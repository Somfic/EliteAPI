using System;

namespace EliteAPI
{
    public class RankInfo
    {
        public DateTime timestamp { get; }
        public int Combat { get; }
        public int Trade { get; }
        public int Explore { get; }
        public int Empire { get; }
        public int Federation { get; }
        public int CQC { get; }
    }
}
