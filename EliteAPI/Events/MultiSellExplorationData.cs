using System;
using System.Collections.Generic;

namespace EliteAPI
{

    public class MultiSellExplorationDataInfo
    {
        public DateTime timestamp { get; set; }
        public string _event { get; set; }
        public List<DiscoveredInfo> Discovered { get; set; }
        public int BaseValue { get; set; }
        public int Bonus { get; set; }
        public int TotalEarnings { get; set; }
    }

    public class DiscoveredInfo
    {
        public string SystemName { get; set; }
        public int NumBodies { get; set; }
    }

}
