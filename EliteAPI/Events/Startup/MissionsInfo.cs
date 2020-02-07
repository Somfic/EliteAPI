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
        /// <see cref="MissionsMissionInfo"/>
        [JsonProperty("Active")]
        public IReadOnlyList<MissionsMissionInfo> Active { get; internal set; }

        /// <summary>
        /// A list of the failed missions, if any.
        /// </summary>
        /// <see cref="MissionsMissionInfo"/>
        [JsonProperty("Failed")]
        public IReadOnlyList<MissionsMissionInfo> Failed { get; internal set; }

        /// <summary>
        /// A list of the completed missions, if any.
        /// </summary>
        /// <see cref="MissionsMissionInfo"/>
        [JsonProperty("Complete")]
        public IReadOnlyList<MissionsMissionInfo> Complete { get; internal set; }

        internal static MissionsInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeMissionsEvent(JsonConvert.DeserializeObject<MissionsInfo>(json, JsonSettings.Settings));
        }
    }
}