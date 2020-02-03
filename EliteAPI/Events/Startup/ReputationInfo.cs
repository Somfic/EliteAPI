using System.ComponentModel.DataAnnotations;
using EliteAPI.Status;
using Newtonsoft.Json;

namespace EliteAPI.Events.Startup
{
    /// <summary>
    /// This event is written when the game has started.
    /// </summary>
    public class ReputationInfo : EventBase
    {
        internal ReputationInfo() { }

        /// <summary>
        /// The commander's reputation with the Empire.
        /// Goes from -100-100.
        /// </summary>
        [JsonProperty("Empire")]
        [Range(-100f, 100f)]
        public float Empire { get; internal set; }

        /// <summary>
        /// The commander's localised title reputation with the Empire.
        /// </summary>
        public string EmpireLocalised => RankUtil.Repuation(Empire);

        /// <summary>
        /// The commander's reputation with the Federation.
        /// Goes from -100-100.
        /// </summary>
        [JsonProperty("Federation")]
        [Range(-100f, 100f)]
        public float Federation { get; internal set; }

        /// <summary>
        /// The commander's localised title reputation with the Federation.
        /// </summary>
        public string FederationLocalised => RankUtil.Repuation(Federation);

        /// <summary>
        /// The commander's reputation with the Independent.
        /// Goes from -100-100.
        /// </summary>
        [JsonProperty("Independent")]
        [Range(-100f, 100f)]
        public float Independent { get; internal set; }

        /// <summary>
        /// The commander's localised title reputation with the Independent.
        /// </summary>
        public string IndependentLocalised => RankUtil.Repuation(Independent);

        /// <summary>
        /// The commander's reputation with the Alliance.
        /// Goes from -100-100.
        /// </summary>
        [JsonProperty("Alliance")]
        [Range(-100f, 100f)]
        public float Alliance { get; internal set; }

        /// <summary>
        /// The commander's localised title reputation with the Alliance.
        /// </summary>
        public string AllianceLocalised => RankUtil.Repuation(Alliance);

        internal static ReputationInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeReputationEvent(JsonConvert.DeserializeObject<ReputationInfo>(json, JsonSettings.Settings));
        }
    }
}