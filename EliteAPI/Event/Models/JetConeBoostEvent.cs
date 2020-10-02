using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class JetConeBoostEvent : EventBase
    {
        internal JetConeBoostEvent() { }

        public static JetConeBoostEvent FromJson(string json) => JsonConvert.DeserializeObject<JetConeBoostEvent>(json);


        [JsonProperty("BoostValue")]
        public float BoostValue { get; internal set; }

        
    }
}