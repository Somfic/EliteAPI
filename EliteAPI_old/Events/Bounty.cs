using System; 

using System.Collections.Generic;

namespace EliteAPI
{
    public class BountyInfo
    {
        public class RewardInfo
        {
            public string Faction { get; set; }
            public int Reward { get; set; }
        }

        public DateTime timestamp { get; set; }
        public List<RewardInfo> Rewards { get; set; }
        public string Target { get; set; }
        public int TotalReward { get; set; }
        public string VictimFaction { get; set; }
    }
}
