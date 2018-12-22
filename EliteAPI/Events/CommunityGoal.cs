using System;
using System.Collections.Generic;

namespace EliteAPI
{

    public class CommunityGoalInfo
    {
        public DateTime timestamp { get; }

        public List<CurrentgoalInfo> CurrentGoals { get; }
    }

    public class CurrentgoalInfo
    {
        public int CGID { get; }
        public string Title { get; }
        public string SystemName { get; }
        public string MarketName { get; }
        public DateTime Expiry { get; }
        public bool IsComplete { get; }
        public long CurrentTotal { get; }
        public int PlayerContribution { get; }
        public int NumContributors { get; }
        public ToptierInfo TopTier { get; }
        public string TierReached { get; }
        public int PlayerPercentileBand { get; }
        public int Bonus { get; }
    }

    public class ToptierInfo
    {
        public string Name { get; }
        public string Bonus { get; }
    }

}
