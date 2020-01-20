using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class StationEconomy
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; internal set; }

        [JsonProperty("Proportion")]
        public double Proportion { get; internal set; }
    }
}