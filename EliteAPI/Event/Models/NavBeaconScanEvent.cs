using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class NavBeaconScanEvent : EventBase
    {
        internal NavBeaconScanEvent() { }

        public static NavBeaconScanEvent FromJson(string json) => JsonConvert.DeserializeObject<NavBeaconScanEvent>(json);


        [JsonProperty("SystemAddress")]
        public string SystemAddress { get; internal set; }

        [JsonProperty("NumBodies")]
        public long NumBodies { get; internal set; }

        
    }
}