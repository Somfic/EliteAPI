using System;

namespace EliteAPI
{
    public class Status
    {
        public DateTime timestamp { get; set; }
        public int Flags { get; set; }
        public int[] Pips { get; set; }
        public int FireGroup { get; set; }
        public int GuiFocus { get; set; }
        public float Fuel { get; set; }
        public float Cargo { get; set; }
    }
}
