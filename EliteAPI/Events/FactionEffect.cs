using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class FactionEffect
    {
        [JsonProperty("Faction")]
        public string Faction { get; internal set; }
        [JsonProperty("Effects")]
        public List<Effect> Effects { get; internal set; }
        [JsonProperty("Influence")]
        public List<Influence> Influence { get; internal set; }
        [JsonProperty("ReputationTrend")]
        public string ReputationTrend { get; internal set; }
        [JsonProperty("Reputation")]
        public string Reputation { get; internal set; }
    }
}