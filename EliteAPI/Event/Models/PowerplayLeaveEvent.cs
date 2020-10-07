using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class PowerplayLeaveEvent : EventBase
    {
        internal PowerplayLeaveEvent() { }

        public static PowerplayLeaveEvent FromJson(string json) => JsonConvert.DeserializeObject<PowerplayLeaveEvent>(json);


        [JsonProperty("Power")]
        public string Power { get; internal set; }

        
    }
}