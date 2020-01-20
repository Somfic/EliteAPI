using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public partial class StationFaction
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }
    }
}