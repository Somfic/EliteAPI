using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class FSDFaction
    {
        [JsonProperty("Faction")]
        public string FactionFaction { get; internal set; }

        [JsonProperty("Amount")]
        public long Amount { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("FactionState")]
        public string FactionState { get; internal set; }

        [JsonProperty("Government")]
        public string Government { get; internal set; }

        [JsonProperty("Influence")]
        public float Influence { get; internal set; }

        [JsonProperty("Allegiance")]
        public string Allegiance { get; internal set; }

        [JsonProperty("Happiness")]
        public string Happiness { get; internal set; }

        [JsonProperty("Happiness_Localised", NullValueHandling = NullValueHandling.Ignore)]
        public string HappinessLocalised { get; internal set; }

        [JsonProperty("MyReputation")]
        public float MyReputation { get; internal set; }

        [JsonProperty("RecoveringStates", NullValueHandling = NullValueHandling.Ignore)]
        public List<IngState> RecoveringStates { get; internal set; }

        [JsonProperty("PendingStates", NullValueHandling = NullValueHandling.Ignore)]
        public List<IngState> PendingStates { get; internal set; }

        [JsonProperty("ActiveStates", NullValueHandling = NullValueHandling.Ignore)]
        public List<ActiveState> ActiveStates { get; internal set; }
    }
}