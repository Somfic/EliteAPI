using System;

namespace EliteAPI
{
    public class DockingDeniedInfo
    {
        public DateTime timestamp { get; }
        public string Reason { get; }
        public long MarketID { get; }
        public string StationName { get; }
        public string StationType { get; }
    }
}
