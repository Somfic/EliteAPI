using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class FSSDiscoveryScanInfo : IEvent
    {
        internal static FSSDiscoveryScanInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeFSSDiscoveryScanEvent(JsonConvert.DeserializeObject<FSSDiscoveryScanInfo>(json, EliteAPI.Events.FSSDiscoveryScanConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Progress")]
        public double Progress { get; internal set; }
        [JsonProperty("BodyCount")]
        public long BodyCount { get; internal set; }
        [JsonProperty("NonBodyCount")]
        public long NonBodyCount { get; internal set; }
    }
}
