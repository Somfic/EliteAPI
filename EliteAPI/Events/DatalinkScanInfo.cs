using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class DatalinkScanInfo : IEvent
    {
        internal static DatalinkScanInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeDatalinkScanEvent(JsonConvert.DeserializeObject<DatalinkScanInfo>(json, EliteAPI.Events.DatalinkScanConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Message")]
        public string Message { get; internal set; }
        [JsonProperty("Message_Localised")]
        public string MessageLocalised { get; internal set; }
    }
}
