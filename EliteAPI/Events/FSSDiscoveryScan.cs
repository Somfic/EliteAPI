using System;

namespace EliteAPI
{
    public class FSSDiscoveryScanInfo
    {
        public DateTime timestamp { get; }
        public float Progress { get; }
        public int BodyCount { get; }
        public int NonBodyCount { get; }
    }
}
