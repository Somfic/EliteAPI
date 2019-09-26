using System; 


namespace EliteAPI
{
    public class DockingTimeoutInfo
    {
        public DateTime timestamp { get; set; }
        public int MarketID { get; set; }
        public string StationName { get; set; }
        public string StationType { get; set; }
    }
}
