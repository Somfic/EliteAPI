using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class CommunityGoalInfo : EventBase
    {
        [JsonProperty("CurrentGoals")]
        public List<CurrentGoal> CurrentGoals { get; internal set; }

        internal static CommunityGoalInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeCommunityGoalEvent(JsonConvert.DeserializeObject<CommunityGoalInfo>(json, JsonSettings.Settings));
        }
    }
}