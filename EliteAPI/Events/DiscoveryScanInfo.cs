using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class DiscoveryScanInfo : EventBase
    {
        internal static DiscoveryScanInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeDiscoveryScanEvent(JsonConvert.DeserializeObject<DiscoveryScanInfo>(json, JsonSettings.Settings));

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }
        [JsonProperty("Bodies")]
        public long Bodies { get; internal set; }
    }
}
