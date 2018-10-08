using System;

namespace EliteAPI
{
    public class ShipyardTransferInfo
    {
        public DateTime timestamp { get; set; }
        public string ShipType { get; set; }
        public string ShipType_Localised { get; set; }
        public int ShipID { get; set; }
        public string System { get; set; }
        public long ShipMarketID { get; set; }
        public double Distance { get; set; }
        public int TransferPrice { get; set; }
        public int TransferTime { get; set; }
        public long MarketID { get; set; }
    }
}
