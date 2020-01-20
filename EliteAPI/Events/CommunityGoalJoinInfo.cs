using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class CommunityGoalJoinInfo : EventBase
    {
        internal static CommunityGoalJoinInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCommunityGoalJoinEvent(JsonConvert.DeserializeObject<CommunityGoalJoinInfo>(json, JsonSettings.Settings));

        [JsonProperty("Name")]
        public string Name { get; internal set; }
        [JsonProperty("System")]
        public string System { get; internal set; }
    }
}
