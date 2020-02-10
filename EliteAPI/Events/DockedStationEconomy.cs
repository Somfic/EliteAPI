using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class DockedStationEconomy
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; internal set; }

        [JsonProperty("Proportion")]
        public float Proportion { get; internal set; }
    }
}