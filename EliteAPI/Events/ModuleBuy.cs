using System;

namespace EliteAPI
{
    public class ModuleBuyInfo
    {
        public DateTime timestamp { get; set; }
        public string Slot { get; set; }
        public string BuyItem { get; set; }
        public string BuyItem_Localised { get; set; }
        public long MarketID { get; set; }
        public int BuyPrice { get; set; }
        public string Ship { get; set; }
        public int ShipID { get; set; }
    }
}
