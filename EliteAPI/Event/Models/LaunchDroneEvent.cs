using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class LaunchDroneEvent : EventBase
    {
        internal LaunchDroneEvent() { }

        public static LaunchDroneEvent FromJson(string json) => JsonConvert.DeserializeObject<LaunchDroneEvent>(json);


        [JsonProperty("Type")]
        public string Type { get; internal set; }

        
    }
}