using Newtonsoft.Json;

namespace EliteAPI.Event.Models.Travel
{
    public class DockedStationFaction
    {
        internal DockedStationFaction() { }

        /// <summary>
        /// The name of the faction.
        /// </summary>
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        /// <summary>
        /// The state of the faction.
        /// </summary>
        [JsonProperty("FactionState")]
        public string State { get; internal set; } //todo: turn this into enum
    }
}