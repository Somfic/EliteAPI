using System;

namespace EliteAPI
{
    public class DockingCancelledInfo
    {
        public DateTime timestamp { get; }
        public long MarketID { get; }
        public string StationName { get; }
        public string StationType { get; }
    }
}
