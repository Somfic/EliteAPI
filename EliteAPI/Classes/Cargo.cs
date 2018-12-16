using System;

namespace EliteAPI
{
    public class Cargo
    {
        public DateTime timestamp { get; set; }
        public string _event { get; set; }
        public string Vessel { get; set; }
        public int Count { get; set; }
        public Inventory[] Inventory { get; set; }
    }

    public class Inventory
    {
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public int Count { get; set; }
        public int Stolen { get; set; }
    }

}
