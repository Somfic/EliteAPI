using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class PowerplayLeaveEvent : EventBase
    {
        internal PowerplayLeaveEvent() { }
        [JsonProperty("Power")]
        public string Power { get; internal set; }

        
    }
}