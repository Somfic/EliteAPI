using System;
using System.Collections.Generic;

namespace EliteAPI
{
    public class SellExplorationDataInfo
    {
        public DateTime timestamp { get; }
        public List<string> Systems { get; }
        public List<string> Discovered { get; }
        public int BaseValue { get; }
        public int Bonus { get; }
        public int TotalEarnings { get; }
    }
}
