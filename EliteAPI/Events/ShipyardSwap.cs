using System;

namespace EliteAPI
{
    public class ShipyardSwapInfo
    {
        public DateTime timestamp { get; set; }
        public string ShipType { get; set; }
        public int ShipID { get; set; }
        public string StoreOldShip { get; set; }
        public int StoreShipID { get; set; }
        public long MarketID { get; set; }
    }
}
