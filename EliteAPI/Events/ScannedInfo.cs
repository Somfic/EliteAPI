using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ScannedInfo : IEvent
    {
        internal static ScannedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeScannedEvent(JsonConvert.DeserializeObject<ScannedInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("ScanType")]
        public string ScanType { get; internal set; }
    }
}
