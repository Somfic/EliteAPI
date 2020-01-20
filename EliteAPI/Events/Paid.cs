using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public partial class Paid
    {
        [JsonProperty("Material")]
        public string Material { get; internal set; }
        [JsonProperty("Material_Localised")]
        public string MaterialLocalised { get; internal set; }
        [JsonProperty("Category")]
        public string Category { get; internal set; }
        [JsonProperty("Category_Localised")]
        public string CategoryLocalised { get; internal set; }
        [JsonProperty("Quantity")]
        public long Quantity { get; internal set; }
    }
}