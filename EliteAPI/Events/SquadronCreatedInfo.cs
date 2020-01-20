using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class SquadronCreatedInfo : IEvent
    {
        internal static SquadronCreatedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeSquadronCreatedEvent(JsonConvert.DeserializeObject<SquadronCreatedInfo>(json, EliteAPI.Events.SquadronCreatedConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("SquadronName")]
        public string SquadronName { get; internal set; }
    }
}
