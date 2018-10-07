using System;
using System.Collections.Generic;

namespace EliteAPI
{
    public class StoredModulesInfo
    {
        public class ItemInfo
        {
            public string Name { get; set; }
            public string Name_Localised { get; set; }
            public int StorageSlot { get; set; }
            public string StarSystem { get; set; }
            public object MarketID { get; set; }
            public int TransferCost { get; set; }
            public int TransferTime { get; set; }
            public int BuyPrice { get; set; }
            public bool Hot { get; set; }
            public string EngineerModifications { get; set; }
            public int Level { get; set; }
            public double Quality { get; set; }
        }

        public DateTime timestamp { get; set; }
        public long MarketID { get; set; }
        public string StationName { get; set; }
        public string StarSystem { get; set; }
        public List<ItemInfo> Items { get; set; }
    }
}
