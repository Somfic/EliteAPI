using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class DisbandedSquadronInfo : IEvent
    {
        internal static DisbandedSquadronInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeDisbandedSquadronEvent(JsonConvert.DeserializeObject<DisbandedSquadronInfo>(json, EliteAPI.Events.DisbandedSquadronConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("SquadronName")]
        public string SquadronName { get; internal set; }
    }
}
