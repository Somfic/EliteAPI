using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class MiningRefinedEvent : EventBase
    {
        internal MiningRefinedEvent() { }
        [JsonProperty("Type")]
        public string Type { get; internal set; }

        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; internal set; }

        
    }
}