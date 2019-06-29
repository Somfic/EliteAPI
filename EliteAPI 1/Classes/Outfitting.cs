using System;
using System.Collections.Generic;
namespace EliteAPI
{
    public class Outfitting
    {
        public DateTime timestamp { get; set; }
        public long MarketID { get; set; }
        public string StationName { get; set; }
        public string StarSystem { get; set; }
        public bool Horizons { get; set; }
        public List<Item> Items { get; set; }
    }

    public class Item
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int BuyPrice { get; set; }
    }

}
