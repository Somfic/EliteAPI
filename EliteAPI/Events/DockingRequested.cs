using System;

namespace EliteAPI
{
    public class DockingRequestedInfo
    {
        public DateTime timestamp { get; set; }
        public long MarketID { get; set; }
        public string StationName { get; set; }
        public string StationType { get; set; }
    }
}
