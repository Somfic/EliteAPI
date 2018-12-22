using System;

namespace EliteAPI
{
    public class MarketSellInfo
    {
        public DateTime timestamp { get; }
        public long MarketID { get; }
        public string Type { get; }
        public string Type_Localised { get; }
        public int Count { get; }
        public int SellPrice { get; }
        public int TotalSale { get; }
        public int AvgPricePaid { get; }
    }
}
