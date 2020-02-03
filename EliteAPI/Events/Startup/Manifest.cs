using Newtonsoft.Json;

namespace EliteAPI.Events.Startup {
    /// <summary>
    /// A record of a group of passengers.
    /// </summary>
    public class Manifest
    {
        internal Manifest() { }

        /// <summary>
        /// The id of mission related to these passengers.
        /// </summary>
        /// <seealso cref="MissionInfo"/>
        [JsonProperty("MissionID")]
        public long MissionId { get; internal set; }

        /// <summary>
        /// The type of passengers.
        /// </summary>
        [JsonProperty("Type")]
        public string Type { get; internal set; }

        /// <summary>
        /// Whether these passengers are VIPs.
        /// </summary>
        [JsonProperty("VIP")]
        public bool Vip { get; internal set; }

        /// <summary>
        /// Whether these passengers are wanted.
        /// </summary>
        [JsonProperty("Wanted")]
        public bool Wanted { get; internal set; }

        /// <summary>
        /// The amount of passengers.
        /// </summary>
        [JsonProperty("Count")]
        public long Count { get; internal set; }
    }
}