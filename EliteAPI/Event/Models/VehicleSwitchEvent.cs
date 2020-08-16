using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class VehicleSwitchEvent : EventBase
    {
        internal VehicleSwitchEvent() { }

        public static VehicleSwitchEvent FromJson(string json) => JsonConvert.DeserializeObject<VehicleSwitchEvent>(json);


        [JsonProperty("To")]
        public string To { get; internal set; }

        
    }
}