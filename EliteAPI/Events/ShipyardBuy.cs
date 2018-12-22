using System;

namespace EliteAPI
{
    public class ShipyardBuyInfo
    {
        public DateTime timestamp { get; }
        public string ShipType { get; }
        public int ShipPrice { get; }
        public string StoreOldShip { get; }
        public int StoreShipID { get; }
        public long MarketID { get; }
    }
}
