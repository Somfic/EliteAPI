using Newtonsoft.Json;

namespace EliteAPI.Events.Startup {
    /// <summary>
    /// Contains information about a mission.
    /// </summary>
    /// <see cref="MissionsInfo"/>
    public class MissionInfo
    {
        internal MissionInfo() { }

        /// <summary>
        /// The id of the mission.
        /// </summary>
        [JsonProperty("MissionID")]
        public long MissionId { get; internal set; }

        /// <summary>
        /// The name of the mission.
        /// </summary>
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        /// <summary>
        /// Whether this mission is a passenger mission.
        /// </summary>
        [JsonProperty("PassengerMission")]
        public bool PassengerMission { get; internal set; }

        /// <summary>
        /// The amount of seconds left for this mission.
        /// </summary>
        [JsonProperty("Expires")]
        public long Expires { get; internal set; }
    }
}