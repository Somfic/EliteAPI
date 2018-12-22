using System;

namespace EliteAPI
{
    public class DockingTimeoutInfo
    {
        public DateTime timestamp { get; }
        public int MarketID { get; }
        public string StationName { get; }
        public string StationType { get; }
    }
}
