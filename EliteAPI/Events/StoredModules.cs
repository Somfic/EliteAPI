using System;
using System.Collections.Generic;

namespace EliteAPI
{
    public class StoredModulesInfo
    {
        public class ItemInfo
        {
            public string Name { get; }
            public string Name_Localised { get; }
            public int StorageSlot { get; }
            public string StarSystem { get; }
            public object MarketID { get; }
            public int TransferCost { get; }
            public int TransferTime { get; }
            public int BuyPrice { get; }
            public bool Hot { get; }
            public string EngineerModifications { get; }
            public int Level { get; }
            public double Quality { get; }
        }

        public DateTime timestamp { get; }
        public long MarketID { get; }
        public string StationName { get; }
        public string StarSystem { get; }
        public List<ItemInfo> Items { get; }
    }
}
