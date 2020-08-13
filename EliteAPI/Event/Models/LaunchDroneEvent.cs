using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class LaunchDroneEvent : EventBase
    {
        internal LaunchDroneEvent() { }
        [JsonProperty("Type")]
        public string Type { get; internal set; }

        
    }
}