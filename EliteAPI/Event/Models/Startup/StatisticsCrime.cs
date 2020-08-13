using Newtonsoft.Json;

namespace EliteAPI.Event.Models.Startup
{
    /// <summary>
    /// Holds statistics on the commander's crime.
    /// </summary>
    /// <see cref="StatisticsInfo"/>
    public class StatisticsCrime
    {
        internal StatisticsCrime() { }

        /// <summary>
        /// Unknown.
        /// </summary>
        [JsonProperty("Notoriety")]
        public long Notoriety { get; internal set; }

        /// <summary>
        /// The total amount of fines issued to the commander.
        /// </summary>
        [JsonProperty("Fines")]
        public int Fines { get; internal set; }

        /// <summary>
        /// The total amount of fines in credits. 
        /// </summary>
        [JsonProperty("Total_Fines")]
        public long TotalFines { get; internal set; }

        /// <summary>
        /// The total amount of bounties issued to the commander.
        /// </summary>
        [JsonProperty("Bounties_Received")]
        public int BountiesReceived { get; internal set; }

        /// <summary>
        /// The total amount of bounties in credits.
        /// </summary>
        [JsonProperty("Total_Bounties")]
        public long TotalBounties { get; internal set; }

        /// <summary>
        /// The highest bounty ever issued to the commander.
        /// </summary>
        [JsonProperty("Highest_Bounty")]
        public long HighestBounty { get; internal set; }
    }
}