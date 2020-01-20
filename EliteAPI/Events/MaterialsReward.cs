using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class MaterialsReward
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }
        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; internal set; }
        [JsonProperty("Category")]
        public string Category { get; internal set; }
        [JsonProperty("Category_Localised")]
        public string CategoryLocalised { get; internal set; }
        [JsonProperty("Count")]
        public long Count { get; internal set; }
    }
}