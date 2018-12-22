using System;
using System.Collections.Generic;

namespace EliteAPI
{

    public class MultiSellExplorationDataInfo
    {
        public DateTime timestamp { get; }

        public List<DiscoveredInfo> Discovered { get; }
        public int BaseValue { get; }
        public int Bonus { get; }
        public int TotalEarnings { get; }
    }

    public class DiscoveredInfo
    {
        public string SystemName { get; }
        public int NumBodies { get; }
    }

}
