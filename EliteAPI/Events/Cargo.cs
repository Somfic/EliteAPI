using System;
using System.Collections.Generic;

namespace EliteAPI
{
    public class CargoInfo
    {
        public class InventoryInfo
        {
            public string Name { get; }
            public string Name_Localised { get; }
            public int Count { get; }
            public int Stolen { get; }
        }

        public DateTime timestamp { get; }
        public List<InventoryInfo> Inventory { get; }
    }
}
