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
        public long CommunitygoalGameId { get; internal set; }
        [JsonProperty("contribution")]
        public long Contribution { get; internal set; }
        [JsonProperty("percentileBand")]
        public long PercentileBand { get; internal set; }
        [JsonProperty("percentileBandReward")]
        public long PercentileBandReward { get; internal set; }
        [JsonProperty("isTopRank")]
        public bool IsTopRank { get; internal set; }
    }
}
