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
}