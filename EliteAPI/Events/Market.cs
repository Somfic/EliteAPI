using System;

namespace EliteAPI
{
    public class MarketInfo
    {
        public DateTime timestamp { get; set; }

        public long MarketID { get; set; }
        public string StationName { get; set; }
        public string StarSystem { get; set; }
    }
}
