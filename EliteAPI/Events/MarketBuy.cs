using System;

namespace EliteAPI
{
    public class MarketBuyInfo
    {
        public DateTime timestamp { get; set; }
        public long MarketID { get; set; }
        public string Type { get; set; }
        public string Type_Localised { get; set; }
        public int Count { get; set; }
        public int BuyPrice { get; set; }
        public int TotalCost { get; set; }
    }
}
