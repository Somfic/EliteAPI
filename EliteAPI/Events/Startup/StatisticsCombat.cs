using Newtonsoft.Json;

namespace EliteAPI.Events.Startup
{
    /// <summary>
    /// Holds statistics on the commander's combat.
    /// </summary>
    /// <see cref="StatisticsInfo"/>
    public class StatisticsCombat
    {
        internal StatisticsCombat() { }

        /// <summary>
        /// The total amount of bounties claimed.
        /// </summary>
        [JsonProperty("Bounties_Claimed")]
        public int BountiesClaimed { get; internal set; }

        /// <summary>
        /// The total amount of profit made from bounties.
        /// </summary>
        [JsonProperty("Bounty_Hunting_Profit")]
        public long BountyHuntingProfit { get; internal set; }

        /// <summary>
        /// The total amount of combat bonds claimed.
        /// </summary>
        [JsonProperty("Combat_Bonds")]
        public int CombatBonds { get; internal set; }

        /// <summary>
        /// The total amount of profit made from combat bonds.
        /// </summary>
        [JsonProperty("Combat_Bond_Profits")]
        public long CombatBondProfits { get; internal set; }

        /// <summary>
        /// The total amount of assassinations done.
        /// </summary>
        [JsonProperty("Assassinations")]
        public long Assassinations { get; internal set; }

        /// <summary>
        /// The total amount of profit made from assassinations.
        /// </summary>
        [JsonProperty("Assassination_Profits")]
        public long AssassinationProfits { get; internal set; }

        /// <summary>
        /// The highest reward ever rewarded to the commander.
        /// </summary>
        [JsonProperty("Highest_Single_Reward")]
        public long HighestSingleReward { get; internal set; }

        /// <summary>
        /// The total amount of skimmers destroyed.
        /// </summary>
        [JsonProperty("Skimmers_Killed")]
        public long SkimmersKilled { get; internal set; }
    }
}