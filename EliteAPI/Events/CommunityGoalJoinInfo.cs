using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class CommunityGoalJoinInfo : IEvent
    {
        internal static CommunityGoalJoinInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCommunityGoalJoinEvent(JsonConvert.DeserializeObject<CommunityGoalJoinInfo>(json, EliteAPI.Events.CommunityGoalJoinConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Name")]
        public string Name { get; internal set; }
        [JsonProperty("System")]
        public string System { get; internal set; }
    }
}
