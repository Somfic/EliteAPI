using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class JetConeBoostEvent : EventBase
    {
        internal JetConeBoostEvent() { }
        [JsonProperty("BoostValue")]
        public float BoostValue { get; internal set; }

        
    }
}