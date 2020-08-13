using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class NavBeaconScanEvent : EventBase
    {
        internal NavBeaconScanEvent() { }
        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        [JsonProperty("NumBodies")]
        public long NumBodies { get; internal set; }

        
    }
}