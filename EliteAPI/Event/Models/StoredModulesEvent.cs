using System.Collections.Generic;
using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class StoredModulesEvent : EventBase
    {
        internal StoredModulesEvent() { }

        public static StoredModulesEvent FromJson(string json) => JsonConvert.DeserializeObject<StoredModulesEvent>(json);


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