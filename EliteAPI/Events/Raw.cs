using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class Raw
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }
    }
}