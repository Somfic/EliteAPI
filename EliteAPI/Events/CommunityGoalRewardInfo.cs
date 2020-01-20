using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class CommunityGoalRewardInfo : IEvent
    {
        internal static CommunityGoalRewardInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCommunityGoalRewardEvent(JsonConvert.DeserializeObject<CommunityGoalRewardInfo>(json, EliteAPI.Events.CommunityGoalRewardConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Name")]
        public string Name { get; internal set; }
        [JsonProperty("System")]
        public string System { get; internal set; }
        [JsonProperty("Reward")]
        public long Reward { get; internal set; }
    }
}
