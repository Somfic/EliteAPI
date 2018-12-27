using System;

namespace EliteAPI
{
    public class CargoDepotInfo
    {
        public DateTime timestamp { get; set; }
        public int MissionID { get; set; }
        public string UpdateType { get; set; }
        public string CargoType { get; set; }
        public string CargoType_Localised { get; set; }
        public int Count { get; set; }
        public long StartMarketID { get; set; }
        public long EndMarketID { get; set; }
        public int ItemsCollected { get; set; }
        public int ItemsDelivered { get; set; }
        public int TotalItemsToDeliver { get; set; }
        public double Progress { get; set; }
    }
}
