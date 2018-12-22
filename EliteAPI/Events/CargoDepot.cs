using System;

namespace EliteAPI
{
    public class CargoDepotInfo
    {
        public DateTime timestamp { get; }
        public int MissionID { get; }
        public string UpdateType { get; }
        public string CargoType { get; }
        public string CargoType_Localised { get; }
        public int Count { get; }
        public long StartMarketID { get; }
        public long EndMarketID { get; }
        public int ItemsCollected { get; }
        public int ItemsDelivered { get; }
        public int TotalItemsToDeliver { get; }
        public double Progress { get; }
    }
}
