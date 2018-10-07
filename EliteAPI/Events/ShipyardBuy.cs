using System;

namespace EliteAPI
{
    public class ShipyardBuyInfo
    {
        public DateTime timestamp { get; set; }
        public string ShipType { get; set; }
        public int ShipPrice { get; set; }
        public string StoreOldShip { get; set; }
        public int StoreShipID { get; set; }
        public long MarketID { get; set; }
    }
}
