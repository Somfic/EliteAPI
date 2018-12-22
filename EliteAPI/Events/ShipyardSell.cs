using System;

namespace EliteAPI
{
    public class ShipyardSellInfo
    {
        public DateTime timestamp { get; }
        public string ShipType { get; }
        public int SellShipID { get; }
        public int ShipPrice { get; }
        public long MarketID { get; }
    }
}
