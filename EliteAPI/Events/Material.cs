using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class Material
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Name_Localised", NullValueHandling = NullValueHandling.Ignore)]
        public string NameLocalised { get; internal set; }

        [JsonProperty("Percent")]
        public double Percent { get; internal set; }
    }
}