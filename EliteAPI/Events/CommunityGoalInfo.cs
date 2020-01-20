using System;
using System.Collections.Generic;

namespace EliteAPI.Events
{
    using Newtonsoft.Json;

    public class CommunityGoalInfo : EventBase
    {
        internal static CommunityGoalInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCommunityGoalEvent(JsonConvert.DeserializeObject<CommunityGoalInfo>(json, JsonSettings.Settings));

        [JsonProperty("CurrentGoals")]
        public List<CurrentGoal> CurrentGoals { get; internal set; }
    }
}
