using System.Collections.Generic;
using EliteAPI.Event.Models.Travel;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class Faction
    {
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

        [JsonProperty("Happiness_Localised")]
        public string HappinessLocalised { get; internal set; }

        [JsonProperty("MyReputation")]
        public float MyReputation { get; internal set; }

        [JsonProperty("ActiveStates", NullValueHandling = NullValueHandling.Ignore)]
        public List<FSDJumpActiveState> ActiveStates { get; internal set; }
    }
}