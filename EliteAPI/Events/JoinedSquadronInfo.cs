using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class JoinedSquadronInfo : IEvent
    {
        internal static JoinedSquadronInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeJoinedSquadronEvent(JsonConvert.DeserializeObject<JoinedSquadronInfo>(json, EliteAPI.Events.JoinedSquadronConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("SquadronName")]
        public string SquadronName { get; internal set; }
    }
}
