using Newtonsoft.Json;

namespace EliteAPI.Inara.Events
{
    public class InaraModifier
    {
        [JsonProperty("name")]
        public string Name { get; internal set; }
        [JsonProperty("value")]
        public decimal Value { get; internal set; }
        [JsonProperty("originalValue", NullValueHandling = NullValueHandling.Ignore)]
        public float? OriginalValue { get; internal set; }
        [JsonProperty("lessIsGood", NullValueHandling = NullValueHandling.Ignore)]
        public bool? LessIsGood { get; internal set; }
    }
}