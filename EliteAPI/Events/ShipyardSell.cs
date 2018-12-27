using System;

namespace EliteAPI
{
    public class ShipyardSellInfo
    {
        public DateTime timestamp { get; set; }
        public string ShipType { get; set; }
        public int SellShipID { get; set; }
        public int ShipPrice { get; set; }
        public long MarketID { get; set; }
    }
}
