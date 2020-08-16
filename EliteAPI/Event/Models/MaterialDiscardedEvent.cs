using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class MaterialDiscardedEvent : EventBase
    {
        internal MaterialDiscardedEvent() { }

        public static MaterialDiscardedEvent FromJson(string json) => JsonConvert.DeserializeObject<MaterialDiscardedEvent>(json);


        [JsonProperty("Category")]
        public string Category { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }

        
    }
}