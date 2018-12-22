using System;

namespace EliteAPI
{
    public class ShipyardTransferInfo
    {
        public DateTime timestamp { get; }
        public string ShipType { get; }
        public string ShipType_Localised { get; }
        public int ShipID { get; }
        public string System { get; }
        public long ShipMarketID { get; }
        public double Distance { get; }
        public int TransferPrice { get; }
        public int TransferTime { get; }
        public long MarketID { get; }
    }
}
