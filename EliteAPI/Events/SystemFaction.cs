using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class SystemFaction
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }
    }
}