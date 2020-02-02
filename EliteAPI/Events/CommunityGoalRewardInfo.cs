using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class CommunityGoalRewardInfo : EventBase
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("System")]
        public string System { get; internal set; }

        [JsonProperty("Reward")]
        public long Reward { get; internal set; }

        internal static CommunityGoalRewardInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeCommunityGoalRewardEvent(JsonConvert.DeserializeObject<CommunityGoalRewardInfo>(json, JsonSettings.Settings));
        }
    }
}