using System;
using System.Collections.Generic;

namespace EliteAPI.Events
{
    using Newtonsoft.Json;

    public class StoredModulesInfo : EventBase
    {
        internal static StoredModulesInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeStoredModulesEvent(JsonConvert.DeserializeObject<StoredModulesInfo>(json, JsonSettings.Settings));

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
