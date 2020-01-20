using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class Combat
    {
        [JsonProperty("Bounties_Claimed")]
        public long BountiesClaimed { get; internal set; }

        [JsonProperty("Bounty_Hunting_Profit")]
        public double BountyHuntingProfit { get; internal set; }

        [JsonProperty("Combat_Bonds")]
        public long CombatBonds { get; internal set; }

        [JsonProperty("Combat_Bond_Profits")]
        public long CombatBondProfits { get; internal set; }

        [JsonProperty("Assassinations")]
        public long Assassinations { get; internal set; }

        [JsonProperty("Assassination_Profits")]
        public long AssassinationProfits { get; internal set; }

        [JsonProperty("Highest_Single_Reward")]
        public long HighestSingleReward { get; internal set; }

        [JsonProperty("Skimmers_Killed")]
        public long SkimmersKilled { get; internal set; }
    }
}