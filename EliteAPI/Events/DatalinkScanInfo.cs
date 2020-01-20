using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class DatalinkScanInfo : EventBase
    {
        internal static DatalinkScanInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeDatalinkScanEvent(JsonConvert.DeserializeObject<DatalinkScanInfo>(json, JsonSettings.Settings));

        [JsonProperty("Message")]
        public string Message { get; internal set; }
        [JsonProperty("Message_Localised")]
        public string MessageLocalised { get; internal set; }
    }
}
