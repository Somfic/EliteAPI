using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class PowerplayJoinEvent : EventBase
    {
        internal PowerplayJoinEvent() { }
        [JsonProperty("Power")]
        public string Power { get; internal set; }

        
    }
}