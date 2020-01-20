using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class StationFaction
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }
    }
}