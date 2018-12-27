using System;

namespace EliteAPI
{
    public class FSSDiscoveryScanInfo
    {
        public DateTime timestamp { get; set; }
        public float Progress { get; set; }
        public int BodyCount { get; set; }
        public int NonBodyCount { get; set; }
    }
}
