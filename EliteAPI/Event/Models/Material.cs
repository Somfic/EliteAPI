using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class Material
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Name_Localised", NullValueHandling = NullValueHandling.Ignore)]
        public string NameLocalised { get; internal set; }

        [JsonProperty("Percent")]
        public float Percent { get; internal set; }
    }
}