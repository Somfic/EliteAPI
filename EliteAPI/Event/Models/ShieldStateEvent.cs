using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class ShieldStateEvent : EventBase
    {
        internal ShieldStateEvent() { }

        public static ShieldStateEvent FromJson(string json) => JsonConvert.DeserializeObject<ShieldStateEvent>(json);


        [JsonProperty("ShieldsUp")]
        public bool ShieldsUp { get; internal set; }

        
    }
}