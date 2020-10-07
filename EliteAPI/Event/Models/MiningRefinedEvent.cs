using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class MiningRefinedEvent : EventBase
    {
        internal MiningRefinedEvent() { }

        public static MiningRefinedEvent FromJson(string json) => JsonConvert.DeserializeObject<MiningRefinedEvent>(json);


        [JsonProperty("Type")]
        public string Type { get; internal set; }

        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; internal set; }

        
    }
}