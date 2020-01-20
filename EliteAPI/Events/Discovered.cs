using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public partial class Discovered
    {
        [JsonProperty("SystemName")]
        public string SystemName { get; internal set; }
        [JsonProperty("NumBodies")]
        public long NumBodies { get; internal set; }
    }
}