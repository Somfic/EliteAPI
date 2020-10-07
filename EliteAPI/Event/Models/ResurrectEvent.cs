using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class ResurrectEvent : EventBase
    {
        internal ResurrectEvent() { }

        public static ResurrectEvent FromJson(string json) => JsonConvert.DeserializeObject<ResurrectEvent>(json);


        [JsonProperty("Option")]
        public string Option { get; internal set; }

        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        [JsonProperty("Bankrupt")]
        public bool Bankrupt { get; internal set; }

        
    }
}