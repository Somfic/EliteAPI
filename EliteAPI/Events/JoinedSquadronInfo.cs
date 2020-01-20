using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class JoinedSquadronInfo : EventBase
    {
        internal static JoinedSquadronInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeJoinedSquadronEvent(JsonConvert.DeserializeObject<JoinedSquadronInfo>(json, JsonSettings.Settings));

        [JsonProperty("SquadronName")]
        public string SquadronName { get; internal set; }
    }
}
