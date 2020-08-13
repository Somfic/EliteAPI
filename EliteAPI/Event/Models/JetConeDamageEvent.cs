using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class JetConeDamageEvent : EventBase
    {
        internal JetConeDamageEvent() { }
        [JsonProperty("Module")]
        public string Module { get; internal set; }

        [JsonProperty("Module_Localised")]
        public string ModuleLocalised { get; internal set; }

        
    }
}