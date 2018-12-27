using System;

namespace EliteAPI
{
    public class LiftoffInfo
    {
        public DateTime timestamp { get; set; }
        public bool PlayerControlled { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
