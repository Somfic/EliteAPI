using System;

namespace EliteAPI
{
    public class MarketSellInfo
    {
        public DateTime timestamp { get; set; }
        public long MarketID { get; set; }
        public string Type { get; set; }
        public string Type_Localised { get; set; }
        public int Count { get; set; }
        public int SellPrice { get; set; }
        public int TotalSale { get; set; }
        public int AvgPricePaid { get; set; }
    }
}
