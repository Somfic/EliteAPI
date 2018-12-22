using System;

namespace EliteAPI
{
    public class ShipyardSwapInfo
    {
        public DateTime timestamp { get; }
        public string ShipType { get; }
        public int ShipID { get; }
        public string StoreOldShip { get; }
        public int StoreShipID { get; }
        public long MarketID { get; }
    }
}
