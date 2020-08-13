using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class ScientificResearchEvent : EventBase
    {
        internal ScientificResearchEvent() { }
        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Category")]
        public string Category { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }

        
    }
}