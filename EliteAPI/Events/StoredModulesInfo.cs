using System;
using System.Collections.Generic;

namespace EliteAPI.Events
{
    using Newtonsoft.Json;

    public class StoredModulesInfo : IEvent
    {
        internal static StoredModulesInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeStoredModulesEvent(JsonConvert.DeserializeObject<StoredModulesInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }
        [JsonProperty("StationName")]
        public string StationName { get; internal set; }
        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }
        [JsonProperty("Items")]
        public List<StoredModuleItem> Items { get; internal set; }
    }
}
