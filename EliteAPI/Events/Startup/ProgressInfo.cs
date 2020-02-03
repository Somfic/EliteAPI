using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace EliteAPI.Events.Startup
{
    /// <summary>
    /// This event is written when the game has started.
    /// </summary>
    /// <seealso cref="RankInfo"/>
    public class ProgressInfo : EventBase
    {
        internal ProgressInfo() { }

        /// <summary>
        /// The rank process in a percentages within Combat the commander has.
        /// Goes from 0-100.
        /// </summary>
        [JsonProperty("Combat")]
        [Range(0, 100)]
        public short Combat { get; internal set; }

        /// <summary>
        /// The rank process in a percentages within Trade the commander has.
        /// Goes from 0-100.
        /// </summary>
        [JsonProperty("Trade")]
        [Range(0, 100)]
        public short Trade { get; internal set; }

        /// <summary>
        /// The rank process in a percentages within Exploration the commander has.
        /// Goes from 0-100.
        /// </summary>
        [JsonProperty("Explore")]
        [Range(0, 100)]
        public short Explore { get; internal set; }

        /// <summary>
        /// The rank process in a percentages within the Empire the commander has.
        /// Goes from 0-100.
        /// </summary>
        [JsonProperty("Empire")]
        [Range(0, 100)]
        public short Empire { get; internal set; }

        /// <summary>
        /// The rank process in a percentages within the Federation the commander has.
        /// Goes from 0-100.
        /// </summary>
        [JsonProperty("Federation")]
        [Range(0, 100)]
        public short Federation { get; internal set; }

        /// <summary>
        /// The rank process in a percentages within CQC the commander has.
        /// Goes from 0-100.
        /// </summary>
        [JsonProperty("CQC")]
        [Range(0, 100)]
        public short Cqc { get; internal set; }

        internal static ProgressInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeProgressEvent(JsonConvert.DeserializeObject<ProgressInfo>(json, JsonSettings.Settings));
        }
    }
}