using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class StoredModulesInfo : EventBase
    {
        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("StationName")]
        public string StationName { get; internal set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        [JsonProperty("Items")]
        public List<StoredModuleItem> Items { get; internal set; }

        internal static StoredModulesInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeStoredModulesEvent(JsonConvert.DeserializeObject<StoredModulesInfo>(json, JsonSettings.Settings));
        }
    }
}