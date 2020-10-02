using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class PowerplayJoinEvent : EventBase
    {
        internal PowerplayJoinEvent() { }

        public static PowerplayJoinEvent FromJson(string json) => JsonConvert.DeserializeObject<PowerplayJoinEvent>(json);


        [JsonProperty("Power")]
        public string Power { get; internal set; }

        
    }
}