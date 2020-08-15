using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class CommunityGoalRewardEvent : EventBase
    {
        internal CommunityGoalRewardEvent() { }
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("System")]
        public string System { get; internal set; }

        [JsonProperty("Reward")]
        public long Reward { get; internal set; }

        
    }
}