using System;

namespace EliteAPI
{
    public class MarketInfo
    {
        public DateTime timestamp { get; }

        public long MarketID { get; }
        public string StationName { get; }
        public string StarSystem { get; }
    }
}
