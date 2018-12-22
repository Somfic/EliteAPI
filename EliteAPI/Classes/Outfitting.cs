using System;
using System.Collections.Generic;
namespace EliteAPI
{
    public class Outfitting
    {
        public DateTime timestamp { get; }
        public long MarketID { get; }
        public string StationName { get; }
        public string StarSystem { get; }
        public bool Horizons { get; }
        public List<Item> Items { get; }
    }

    public class Item
    {
        public int id { get; }
        public string Name { get; }
        public int BuyPrice { get; }
    }

}
