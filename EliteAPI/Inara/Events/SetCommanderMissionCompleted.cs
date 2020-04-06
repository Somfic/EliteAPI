using System.Collections.Generic;
using Newtonsoft.Json;
namespace EliteAPI.Inara.Events
{
    public class SetCommanderMissionCompleted : IInaraEventData
    {
        public SetCommanderMissionCompleted(long missionGameId)
        {
            MissionGameId = missionGameId;
        }
        [JsonProperty("missionGameID")]
        public long MissionGameId { get; set; }
        [JsonProperty("donationCredits")]
        public long DonationCredits { get; set; }
        [JsonProperty("rewardCredits")]
        public long RewardCredits { get; set; }
        [JsonProperty("rewardPermits")]
        public List<InaraRewardPermit> RewardPermits { get; set; }
        [JsonProperty("rewardCommodities")]
        public List<InaraReward> RewardCommodities { get; set; }
        [JsonProperty("rewardMaterials")]
        public List<InaraReward> RewardMaterials { get; set; }
    }
    public class InaraReward
    {
        [JsonProperty("itemName")]
        public string ItemName { get; set; }
        [JsonProperty("itemCount")]
        public long ItemCount { get; set; }
    }
    public class InaraRewardPermit
    {
        [JsonProperty("starsystemName")]
        public string StarsystemName { get; set; }
    }
}
