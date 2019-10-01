using System; 


namespace EliteAPI
{
    public class NavBeaconScanInfo
    {
        public DateTime timestamp { get; set; }
        public long SystemAddress { get; set; }
        public int NumBodies { get; set; }
    }
}
