using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class CommunityGoalDiscardInfo : EventBase
    {
        internal static CommunityGoalDiscardInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCommunityGoalDiscardEvent(JsonConvert.DeserializeObject<CommunityGoalDiscardInfo>(json, JsonSettings.Settings));

        [JsonProperty("Name")]
        public string Name { get; internal set; }
        [JsonProperty("System")]
        public string System { get; internal set; }
    }
}
