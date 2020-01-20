using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class DataScannedInfo : IEvent
    {
        internal static DataScannedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeDataScannedEvent(JsonConvert.DeserializeObject<DataScannedInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Type")]
        public string Type { get; internal set; }
        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; internal set; }
    }
}
