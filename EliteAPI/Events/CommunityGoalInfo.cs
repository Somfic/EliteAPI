using System;
using System.Collections.Generic;

namespace EliteAPI.Events
{
    using Newtonsoft.Json;

    public class CommunityGoalInfo : IEvent
    {
        internal static CommunityGoalInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCommunityGoalEvent(JsonConvert.DeserializeObject<CommunityGoalInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("CurrentGoals")]
        public List<CurrentGoal> CurrentGoals { get; internal set; }
    }
}
