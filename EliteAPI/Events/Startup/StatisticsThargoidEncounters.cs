using Newtonsoft.Json;

namespace EliteAPI.Events.Startup
{
    /// <summary>
    /// Holds statistics on the commander's thargoid encounters.
    /// </summary>
    /// <see cref="StatisticsInfo"/>
    public class StatisticsThargoidEncounters
    {
        internal StatisticsThargoidEncounters() { }

        /// <summary>
        /// The total amount of thargoids encountered.
        /// </summary>
        [JsonProperty("TG_ENCOUNTER_TOTAL")]
        public int Total { get; internal set; }

        /// <summary>
        /// The last system a thargoid had been encountered.
        /// </summary>
        [JsonProperty("TG_ENCOUNTER_TOTAL_LAST_SYSTEM")]
        public string LastSystem { get; internal set; }

        /// <summary>
        /// The last in-game timestamp a thargoid had been encountered.
        /// </summary>
        /// <example>3305-05-03 10:01</example>
        [JsonProperty("TG_ENCOUNTER_TOTAL_LAST_TIMESTAMP")]
        public string LastTimestamp { get; internal set; }

        /// <summary>
        /// The ship in which the last thargoid was encountered.
        /// </summary>
        [JsonProperty("TG_ENCOUNTER_TOTAL_LAST_SHIP")]
        public string LastShip { get; internal set; }

        /// <summary>
        /// The amount of thargoids in the scout.
        /// </summary>
        [JsonProperty("TG_SCOUT_COUNT")]
        public long ScoutCount { get; internal set; }
    }
}