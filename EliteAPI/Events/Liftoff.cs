using System;

namespace EliteAPI
{
    public class LiftoffInfo
    {
        public DateTime timestamp { get; }
        public bool PlayerControlled { get; }
        public double Latitude { get; }
        public double Longitude { get; }
    }
}
