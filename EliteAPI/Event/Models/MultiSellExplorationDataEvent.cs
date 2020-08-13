using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class MultiSellExplorationDataEvent : EventBase
    {
        internal MultiSellExplorationDataEvent() { }
        [JsonProperty("Discovered")]
        public List<Discovered> Discovered { get; internal set; }

        [JsonProperty("BaseValue")]
        public long BaseValue { get; internal set; }

        [JsonProperty("Bonus")]
        public long Bonus { get; internal set; }

        [JsonProperty("TotalEarnings")]
        public long TotalEarnings { get; internal set; }

        
    }
}