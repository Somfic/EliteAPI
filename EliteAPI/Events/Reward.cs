using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class Reward
    {
        [JsonProperty("Faction")]
        public string Faction { get; internal set; }

        [JsonProperty("Reward")]
        public long RewardReward { get; internal set; }
    }
}