using System;
using System.Collections.Generic;

namespace EliteAPI
{
    public class SellExplorationDataInfo
    {
        public DateTime timestamp { get; set; }
        public List<string> Systems { get; set; }
        public List<string> Discovered { get; set; }
        public int BaseValue { get; set; }
        public int Bonus { get; set; }
        public int TotalEarnings { get; set; }
    }
}
