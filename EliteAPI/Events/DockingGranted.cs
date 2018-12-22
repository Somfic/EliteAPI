using System;

namespace EliteAPI
{
    public class DockingGrantedInfo
    {
        public DateTime timestamp { get; }
        public int LandingPad { get; }
        public long MarketID { get; }
        public string StationName { get; }
        public string StationType { get; }
    }
}
