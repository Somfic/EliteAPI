using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class AppliedToSquadronInfo : IEvent
    {
        internal static AppliedToSquadronInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeAppliedToSquadronEvent(JsonConvert.DeserializeObject<AppliedToSquadronInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("SquadronName")]
        public string SquadronName { get; internal set; }
    }
}
