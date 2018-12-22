using System;

namespace EliteAPI
{
    public class ModuleBuyInfo
    {
        public DateTime timestamp { get; }
        public string Slot { get; }
        public string BuyItem { get; }
        public string BuyItem_Localised { get; }
        public long MarketID { get; }
        public int BuyPrice { get; }
        public string Ship { get; }
        public int ShipID { get; }
    }
}
