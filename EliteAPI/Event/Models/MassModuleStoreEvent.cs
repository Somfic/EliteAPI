using System.Collections.Generic;
using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class MassModuleStoreEvent : EventBase
    {
        internal MassModuleStoreEvent() { }

        public static MassModuleStoreEvent FromJson(string json) => JsonConvert.DeserializeObject<MassModuleStoreEvent>(json);


        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("Ship")]
        public string Ship { get; internal set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }

        [JsonProperty("Items")]
        public List<Item> Items { get; internal set; }

        
    }
}