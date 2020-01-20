using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class DiscoveryScanInfo : IEvent
    {
        internal static DiscoveryScanInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeDiscoveryScanEvent(JsonConvert.DeserializeObject<DiscoveryScanInfo>(json, EliteAPI.Events.DiscoveryScanConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }
        [JsonProperty("Bodies")]
        public long Bodies { get; internal set; }
    }
}
