using Newtonsoft.Json;

namespace EliteAPI.Event.Models.Travel
{
    public class FSDJumpSystemFaction
    {
        internal FSDJumpSystemFaction() { }

        /// <summary>
        /// The name of the faction.
        /// </summary>
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        /// <summary>
        /// The state of the faction.
        /// </summary>
        [JsonProperty("FactionState")]
        public string FactionState { get; internal set; } //todo: turn this into an enum
    }
}