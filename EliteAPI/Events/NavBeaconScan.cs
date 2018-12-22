using System;

namespace EliteAPI
{
    public class NavBeaconScanInfo
    {
        public DateTime timestamp { get; }
        public long SystemAddress { get; }
        public int NumBodies { get; }
    }
}
