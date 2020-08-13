using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class InterdictedEvent : EventBase
    {
        internal InterdictedEvent() { }
        [JsonProperty("Submitted")]
        public bool Submitted { get; internal set; }

        [JsonProperty("Interdictor")]
        public string Interdictor { get; internal set; }

        [JsonProperty("Interdictor_Localised")]
        public string InterdictorLocalised { get; internal set; }

        [JsonProperty("IsPlayer")]
        public bool IsPlayer { get; internal set; }

        [JsonProperty("Faction")]
        public string Faction { get; internal set; }

        
    }
}