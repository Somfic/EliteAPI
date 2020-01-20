using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class NavBeaconScanInfo : IEvent
    {
        internal static NavBeaconScanInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeNavBeaconScanEvent(JsonConvert.DeserializeObject<NavBeaconScanInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }
        [JsonProperty("NumBodies")]
        public long NumBodies { get; internal set; }
    }
}
