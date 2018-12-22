using System;

namespace EliteAPI
{
    public class DockingRequestedInfo
    {
        public DateTime timestamp { get; }
        public long MarketID { get; }
        public string StationName { get; }
        public string StationType { get; }
    }
}
