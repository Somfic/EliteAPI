using System;

namespace EliteAPI
{
    public class ModuleSellInfo
    {
        public DateTime timestamp { get; }
        public long MarketID { get; }
        public string Slot { get; }
        public string SellItem { get; }
        public string SellItem_Localised { get; }
        public int SellPrice { get; }
        public string Ship { get; }
        public int ShipID { get; }
    }
}
