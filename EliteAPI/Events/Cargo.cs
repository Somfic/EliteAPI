using System;
using System.Collections.Generic;

namespace EliteAPI
{
    public class CargoInfo
    {
        public class InventoryInfo
        {
            public string Name { get; set; }
            public string Name_Localised { get; set; }
            public int Count { get; set; }
            public int Stolen { get; set; }
        }

        public DateTime timestamp { get; set; }
        public List<InventoryInfo> Inventory { get; set; }
    }
}
