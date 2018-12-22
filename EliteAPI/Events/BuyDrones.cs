using System;

namespace EliteAPI
{
    public class BuyDronesInfo
    {
        public DateTime timestamp { get; }
        public string Type { get; }
        public int Count { get; }
        public int BuyPrice { get; }
        public int TotalCost { get; }
    }
}
