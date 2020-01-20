using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class Commodity
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }

        [JsonProperty("Category", NullValueHandling = NullValueHandling.Ignore)]
        public string Category { get; internal set; }
    }
}