using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class LeftSquadronInfo : IEvent
    {
        internal static LeftSquadronInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeLeftSquadronEvent(JsonConvert.DeserializeObject<LeftSquadronInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("SquadronName")]
        public string SquadronName { get; internal set; }
    }
}
