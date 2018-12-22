using System;
using System.Collections.Generic;

namespace EliteAPI
{
    public class BountyInfo
    {
        public class RewardInfo
        {
            public string Faction { get; }
            public int Reward { get; }
        }

        public DateTime timestamp { get; }
        public List<RewardInfo> Rewards { get; }
        public string Target { get; }
        public int TotalReward { get; }
        public string VictimFaction { get; }
    }
}
