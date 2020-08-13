using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class ShieldStateEvent : EventBase
    {
        internal ShieldStateEvent() { }
        [JsonProperty("ShieldsUp")]
        public bool ShieldsUp { get; internal set; }

        
    }
}