using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class UnderAttackEvent : EventBase
    {
        internal UnderAttackEvent() { }
        [JsonProperty("Target")]
        public string Target { get; internal set; }

        
    }
}