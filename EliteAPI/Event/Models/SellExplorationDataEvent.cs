using System.Collections.Generic;
using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class SellExplorationDataEvent : EventBase
    {
        internal SellExplorationDataEvent() { }

        public static SellExplorationDataEvent FromJson(string json) => JsonConvert.DeserializeObject<SellExplorationDataEvent>(json);


        [JsonProperty("Systems")]
        public List<string> Systems { get; internal set; }

        [JsonProperty("Discovered")]
        public List<string> Discovered { get; internal set; }

        [JsonProperty("BaseValue")]
        public long BaseValue { get; internal set; }

        [JsonProperty("Bonus")]
        public long Bonus { get; internal set; }

        [JsonProperty("TotalEarnings")]
        public long TotalEarnings { get; internal set; }

        
    }
}