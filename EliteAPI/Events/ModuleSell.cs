using System;

namespace EliteAPI
{
    public class ModuleSellInfo
    {
        public DateTime timestamp { get; set; }
        public long MarketID { get; set; }
        public string Slot { get; set; }
        public string SellItem { get; set; }
        public string SellItem_Localised { get; set; }
        public int SellPrice { get; set; }
        public string Ship { get; set; }
        public int ShipID { get; set; }
    }
}
