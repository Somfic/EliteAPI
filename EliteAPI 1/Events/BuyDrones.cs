using System; 


namespace EliteAPI
{
    public class BuyDronesInfo
    {
        public DateTime timestamp { get; set; }
        public string Type { get; set; }
        public int Count { get; set; }
        public int BuyPrice { get; set; }
        public int TotalCost { get; set; }
    }
}
