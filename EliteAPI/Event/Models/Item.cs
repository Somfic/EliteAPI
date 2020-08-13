using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class Item
    {
        [JsonProperty("Slot")]
        public string Slot { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; internal set; }

        [JsonProperty("Hot")]
        public bool Hot { get; internal set; }

        [JsonProperty("EngineerModifications")]
        public string EngineerModifications { get; internal set; }

        [JsonProperty("Level")]
        public long Level { get; internal set; }

        [JsonProperty("Quality")]
        public float Quality { get; internal set; }
    }
}