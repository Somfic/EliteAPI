using EliteAPI.Event.Helper;
using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models.Startup
{
    /// <summary>
    /// This event is written when the game has started.
    /// </summary>
    public class ReputationEvent : EventBase
    {
        internal ReputationEvent() { }

        public static ReputationEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ReputationEvent>(json);
        }



        /// <summary>
        /// The commander's reputation with the Empire.
        /// Goes from -100-100.
        /// </summary>
        [JsonProperty("Empire")]
        public float Empire { get; internal set; }

        /// <summary>
        /// The commander's localised title reputation with the Empire.
        /// </summary>
        public string EmpireLocalised => RankHelper.Reputation(Empire);

        /// <summary>
        /// The commander's reputation with the Federation.
        /// Goes from -100-100.
        /// </summary>
        [JsonProperty("Federation")]
        public float Federation { get; internal set; }

        /// <summary>
        /// The commander's localised title reputation with the Federation.
        /// </summary>
        public string FederationLocalised => RankHelper.Reputation(Federation);

        /// <summary>
        /// The commander's reputation with the Independent.
        /// Goes from -100-100.
        /// </summary>
        [JsonProperty("Independent")]
        public float Independent { get; internal set; }

        /// <summary>
        /// The commander's localised title reputation with the Independent.
        /// </summary>
        public string IndependentLocalised => RankHelper.Reputation(Independent);

        /// <summary>
        /// The commander's reputation with the Alliance.
        /// Goes from -100-100.
        /// </summary>
        [JsonProperty("Alliance")]
        public float Alliance { get; internal set; }

        /// <summary>
        /// The commander's localised title reputation with the Alliance.
        /// </summary>
        public string AllianceLocalised => RankHelper.Reputation(Alliance);


    }
}