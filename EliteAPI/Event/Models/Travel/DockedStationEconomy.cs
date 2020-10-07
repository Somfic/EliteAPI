using Newtonsoft.Json;

namespace EliteAPI.Event.Models.Travel
{
    public class DockedStationEconomy
    {
        internal DockedStationEconomy() { }

        /// <summary>
        /// The type of economy.
        /// </summary>
        [JsonProperty("Name")]
        public string Name { get; internal set; } // todo: Turn this into an enum.

        /// <summary>
        /// The type of economy localised.
        /// </summary>
        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; internal set; } 

        /// <summary>
        /// The proportion of this economy in the station.
        /// </summary>
        [JsonProperty("Proportion")]
        public float Proportion { get; internal set; }
    }
}