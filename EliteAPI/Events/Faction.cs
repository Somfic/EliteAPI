using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public partial class Faction
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }
        [JsonProperty("FactionState")]
        public string FactionState { get; internal set; }
        [JsonProperty("Government")]
        public string Government { get; internal set; }
        [JsonProperty("Influence")]
        public double Influence { get; internal set; }
        [JsonProperty("Allegiance")]
        public string Allegiance { get; internal set; }
        [JsonProperty("Happiness")]
        public string Happiness { get; internal set; }
        [JsonProperty("Happiness_Localised")]
        public string HappinessLocalised { get; internal set; }
        [JsonProperty("MyReputation")]
        public double MyReputation { get; internal set; }
        [JsonProperty("ActiveStates", NullValueHandling = NullValueHandling.Ignore)]
        public List<ActiveState> ActiveStates { get; internal set; }
    }
}