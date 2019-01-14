using System;

using Newtonsoft.Json;

namespace EliteAPI.Inara.Events
{
    public class SetCommunityGoal : IInaraEventData
    {
        public SetCommunityGoal(long communitygoalGameId, string communitygoalName, string starsystemName, string stationName, DateTime goalExpiry)
        {
            CommunitygoalGameId = communitygoalGameId;
            CommunitygoalName = communitygoalName;
            StarsystemName = starsystemName;
            StationName = stationName;
            GoalExpiry = goalExpiry;
        }

        [JsonProperty("communitygoalGameID")]
        public long CommunitygoalGameId { get; set; }

        [JsonProperty("communitygoalName")]
        public string CommunitygoalName { get; set; }

        [JsonProperty("starsystemName")]
        public string StarsystemName { get; set; }

        [JsonProperty("stationName")]
        public string StationName { get; set; }

        [JsonProperty("goalExpiry")]
        public DateTime GoalExpiry { get; set; }

        [JsonProperty("tierReached")]
        public long TierReached { get; set; }

        [JsonProperty("tierMax")]
        public long TierMax { get; set; }

        [JsonProperty("topRankSize")]
        public long TopRankSize { get; set; }

        [JsonProperty("isCompleted")]
        public bool IsCompleted { get; set; }

        [JsonProperty("contributorsNum")]
        public long ContributorsNum { get; set; }

        [JsonProperty("contributionsTotal")]
        public long ContributionsTotal { get; set; }

        [JsonProperty("completionBonus")]
        public string CompletionBonus { get; set; }
    }
}
