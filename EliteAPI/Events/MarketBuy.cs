using System;

namespace EliteAPI
{
    public class MarketBuyInfo
    {
        public DateTime timestamp { get; }
        public long MarketID { get; }
        public string Type { get; }
        public string Type_Localised { get; }
        public int Count { get; }
        public int BuyPrice { get; }
        public int TotalCost { get; }
    }
}
