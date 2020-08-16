using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class SearchAndRescueEvent : EventBase
    {
        internal SearchAndRescueEvent() { }

        public static SearchAndRescueEvent FromJson(string json) => JsonConvert.DeserializeObject<SearchAndRescueEvent>(json);


        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }

        [JsonProperty("Reward")]
        public long Reward { get; internal set; }

        
    }
}