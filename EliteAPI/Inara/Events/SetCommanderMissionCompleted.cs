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
        public long MissionGameId { get; internal set; }

        [JsonProperty("donationCredits")]
        public long DonationCredits { get; internal set; }

        [JsonProperty("rewardCredits")]
        public long RewardCredits { get; internal set; }

        [JsonProperty("rewardPermits")]
        public List<InaraRewardPermit> RewardPermits { get; internal set; }

        [JsonProperty("rewardCommodities")]
        public List<InaraReward> RewardCommodities { get; internal set; }

        [JsonProperty("rewardMaterials")]
        public List<InaraReward> RewardMaterials { get; internal set; }
    }

    public class InaraReward
    {
        [JsonProperty("itemName")]
        public string ItemName { get; internal set; }

        [JsonProperty("itemCount")]
        public long ItemCount { get; internal set; }
    }

    public class InaraRewardPermit
    {
        [JsonProperty("starsystemName")]
        public string StarsystemName { get; internal set; }
    }
}
