using System;
using System.Collections.Generic;

namespace EliteAPI
{

    public class CommunityGoalInfo
    {
        public DateTime timestamp { get; set; }
        public string _event { get; set; }
        public List<CurrentgoalInfo> CurrentGoals { get; set; }
    }

    public class CurrentgoalInfo
    {
        public int CGID { get; set; }
        public string Title { get; set; }
        public string SystemName { get; set; }
        public string MarketName { get; set; }
        public DateTime Expiry { get; set; }
        public bool IsComplete { get; set; }
        public long CurrentTotal { get; set; }
        public int PlayerContribution { get; set; }
        public int NumContributors { get; set; }
        public ToptierInfo TopTier { get; set; }
        public string TierReached { get; set; }
        public int PlayerPercentileBand { get; set; }
        public int Bonus { get; set; }
    }

    public class ToptierInfo
    {
        public string Name { get; set; }
        public string Bonus { get; set; }
    }

}
