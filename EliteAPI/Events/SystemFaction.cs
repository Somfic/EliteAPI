using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class SystemFaction
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("FactionState")]
        public string FactionState { get; internal set; }
    }
}