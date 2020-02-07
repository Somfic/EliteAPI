using Newtonsoft.Json;

namespace EliteAPI.Events.Startup
{
    /// <summary>
    /// Holds statistics on the commander's exploration.
    /// </summary>
    /// <see cref="StatisticsInfo"/>
    public class StatisticsExploration
    {
        internal StatisticsExploration() { }

        /// <summary>
        /// The total amount of systems visited.
        /// </summary>
        [JsonProperty("Systems_Visited")]
        public int SystemsVisited { get; internal set; }

        /// <summary>
        /// The total amount of profit gained by exploration.
        /// </summary>
        [JsonProperty("Exploration_Profits")]
        public long ExplorationProfits { get; internal set; }

        /// <summary>
        /// The total amount of planets scanned to level 2.
        /// </summary>
        [JsonProperty("Planets_Scanned_To_Level_2")]
        public int PlanetsScannedToLevel2 { get; internal set; }

        /// <summary>
        /// The total amount of planets scanned to level 3.
        /// </summary>
        [JsonProperty("Planets_Scanned_To_Level_3")]
        public int PlanetsScannedToLevel3 { get; internal set; }

        /// <summary>
        /// The total amount of efficient scans done by.
        /// </summary>
        [JsonProperty("Efficient_Scans")]
        public int EfficientScans { get; internal set; }

        /// <summary>
        /// The highest payout ever received by the commander.
        /// </summary>
        [JsonProperty("Highest_Payout")]
        public long HighestPayout { get; internal set; }

        /// <summary>
        /// The total amount of distance jumped in light-years.
        /// </summary>
        [JsonProperty("Total_Hyperspace_Distance")]
        public int TotalHyperspaceDistance { get; internal set; }

        /// <summary>
        /// The total amount of hyperspace jumps made.
        /// </summary>
        [JsonProperty("Total_Hyperspace_Jumps")]
        public int TotalHyperspaceJumps { get; internal set; }

        /// <summary>
        /// The greatest distance from the starting location in light-years.
        /// </summary>
        [JsonProperty("Greatest_Distance_From_Start")]
        public float GreatestDistanceFromStart { get; internal set; }

        /// <summary>
        /// The total amount of seconds played.
        /// </summary>
        [JsonProperty("Time_Played")]
        public long TimePlayed { get; internal set; }
    }
}