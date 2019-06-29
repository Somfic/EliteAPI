using System;

namespace EliteAPI
{
    public class FSSSignalDiscoveredInfo
    {
        public DateTime timestamp { get; set; }
        public long SystemAddress { get; set; }
        public string SignalName { get; set; }
        public string SignalName_Localised { get; set; }
    }
}
