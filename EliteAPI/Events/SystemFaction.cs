using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public partial class SystemFaction
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }
    }
}