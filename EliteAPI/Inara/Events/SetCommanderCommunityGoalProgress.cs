using Newtonsoft.Json;
namespace EliteAPI.Inara.Events
{
    public class SetCommanderCommunityGoalProgress : IInaraEventData
    {
        public SetCommanderCommunityGoalProgress(long communitygoalGameId, long contribution, long percentileBand, long percentileBandReward)
        {
            CommunitygoalGameId = communitygoalGameId;
            Contribution = contribution;
            PercentileBand = percentileBand;
            PercentileBandReward = percentileBandReward;
        }
        [JsonProperty("communitygoalGameID")]
        public long CommunitygoalGameId { get; set; }
        [JsonProperty("contribution")]
        public long Contribution { get; set; }
        [JsonProperty("percentileBand")]
        public long PercentileBand { get; set; }
        [JsonProperty("percentileBandReward")]
        public long PercentileBandReward { get; set; }
        [JsonProperty("isTopRank")]
        public bool IsTopRank { get; set; }
    }
}
