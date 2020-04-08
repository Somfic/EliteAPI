using Newtonsoft.Json;

namespace EliteAPI.Inara.Events
{
    public class InaraEngineering
    {
        [JsonProperty("blueprintName")]
        public string BlueprintName { get; set; }
        [JsonProperty("blueprintLevel")]
        public long BlueprintLevel { get; set; }
        [JsonProperty("blueprintQuality")]
        public long BlueprintQuality { get; set; }
        [JsonProperty("experimentalEffect")]
        public string ExperimentalEffect { get; set; }
    }
}