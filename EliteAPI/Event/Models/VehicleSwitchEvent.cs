using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class VehicleSwitchEvent : EventBase
    {
        internal VehicleSwitchEvent() { }
        [JsonProperty("To")]
        public string To { get; internal set; }

        
    }
}