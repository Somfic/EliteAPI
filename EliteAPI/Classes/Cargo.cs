using System;

namespace EliteAPI
{
    public class Cargo
    {
        public DateTime timestamp { get; }

        public string Vessel { get; }
        public int Count { get; }
        public Inventory[] Inventory { get; }
    }

    public class Inventory
    {
        public string Name { get; }
        public string Name_Localised { get; }
        public int Count { get; }
        public int Stolen { get; }
    }

}
