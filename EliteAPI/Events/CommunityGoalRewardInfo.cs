using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class CommunityGoalRewardInfo : EventBase
    {
        internal static CommunityGoalRewardInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCommunityGoalRewardEvent(JsonConvert.DeserializeObject<CommunityGoalRewardInfo>(json, JsonSettings.Settings));

        [JsonProperty("Name")]
        public string Name { get; internal set; }
        [JsonProperty("System")]
        public string System { get; internal set; }
        [JsonProperty("Reward")]
        public long Reward { get; internal set; }
    }
}
