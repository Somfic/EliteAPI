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
        public long CommunitygoalGameId { get; internal set; }

        [JsonProperty("communitygoalName")]
        public string CommunitygoalName { get; internal set; }

        [JsonProperty("starsystemName")]
        public string StarsystemName { get; internal set; }

        [JsonProperty("stationName")]
        public string StationName { get; internal set; }

        [JsonProperty("goalExpiry")]
        public DateTime GoalExpiry { get; internal set; }

        [JsonProperty("tierReached")]
        public long TierReached { get; internal set; }

        [JsonProperty("tierMax")]
        public long TierMax { get; internal set; }

        [JsonProperty("topRankSize")]
        public long TopRankSize { get; internal set; }

        [JsonProperty("isCompleted")]
        public bool IsCompleted { get; internal set; }

        [JsonProperty("contributorsNum")]
        public long ContributorsNum { get; internal set; }

        [JsonProperty("contributionsTotal")]
        public long ContributionsTotal { get; internal set; }

        [JsonProperty("completionBonus")]
        public string CompletionBonus { get; internal set; }
    }
}
