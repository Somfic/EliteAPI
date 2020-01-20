using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class SquadronStartupInfo : EventBase
    {
        internal static SquadronStartupInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeSquadronStartupEvent(JsonConvert.DeserializeObject<SquadronStartupInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("SquadronName")]
        public string SquadronName { get; set; }

        [JsonProperty("CurrentRank")]
        public long CurrentRank { get; set; }
    }
}
