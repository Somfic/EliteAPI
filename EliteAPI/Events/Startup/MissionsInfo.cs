using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events.Startup
{
    /// <summary>
    /// This event is written when the game has started.
    /// </summary>
    public class MissionsInfo : EventBase
    {
        internal MissionsInfo() { }

        /// <summary>
        /// A list of the active missions, if any.
        /// </summary>
        /// <see cref="MissionInfo"/>
        [JsonProperty("Active")]
        public IReadOnlyList<MissionInfo> Active { get; internal set; }

        /// <summary>
        /// A list of the failed missions, if any.
        /// </summary>
        /// <see cref="MissionInfo"/>
        [JsonProperty("Failed")]
        public IReadOnlyList<MissionInfo> Failed { get; internal set; }

        /// <summary>
        /// A list of the completed missions, if any.
        /// </summary>
        /// <see cref="MissionInfo"/>
        [JsonProperty("Complete")]
        public IReadOnlyList<MissionInfo> Complete { get; internal set; }

        internal static MissionsInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeMissionsEvent(JsonConvert.DeserializeObject<MissionsInfo>(json, JsonSettings.Settings));
        }
    }

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