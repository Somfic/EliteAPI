using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class NavBeaconScanInfo : EventBase
    {
        internal static NavBeaconScanInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeNavBeaconScanEvent(JsonConvert.DeserializeObject<NavBeaconScanInfo>(json, JsonSettings.Settings));

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }
        [JsonProperty("NumBodies")]
        public long NumBodies { get; internal set; }
    }
}
