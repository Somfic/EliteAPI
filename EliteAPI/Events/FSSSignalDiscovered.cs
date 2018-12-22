using System;

namespace EliteAPI
{
    public class FSSSignalDiscoveredInfo
    {
        public DateTime timestamp { get; }
        public long SystemAddress { get; }
        public string SignalName { get; }
        public string SignalName_Localised { get; }
    }
}
