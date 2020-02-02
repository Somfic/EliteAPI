using Newtonsoft.Json;

namespace EliteAPI.Status
{
    public partial class Item
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }
        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; internal set; }
        [JsonProperty("Count")]
        public long Count { get; internal set; }
        [JsonProperty("Stolen")]
        public long Stolen { get; internal set; }
    }
}