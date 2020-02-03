using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class ProspectedMaterial
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Name_Localised", NullValueHandling = NullValueHandling.Ignore)]
        public string NameLocalised { get; set; }

        [JsonProperty("Proportion")]
        public float Proportion { get; set; }
    }
}