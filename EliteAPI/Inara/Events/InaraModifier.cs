using Newtonsoft.Json;

namespace EliteAPI.Inara.Events
{
    public class InaraModifier
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("value")]
        public decimal Value { get; set; }
        [JsonProperty("originalValue", NullValueHandling = NullValueHandling.Ignore)]
        public float? OriginalValue { get; set; }
        [JsonProperty("lessIsGood", NullValueHandling = NullValueHandling.Ignore)]
        public bool? LessIsGood { get; set; }
    }
}