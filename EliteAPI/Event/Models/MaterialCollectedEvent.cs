using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class MaterialCollectedEvent : EventBase
    {
        internal MaterialCollectedEvent() { }

        public static MaterialCollectedEvent FromJson(string json) => JsonConvert.DeserializeObject<MaterialCollectedEvent>(json);


        [JsonProperty("Category")]
        public string Category { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }

        
    }
}