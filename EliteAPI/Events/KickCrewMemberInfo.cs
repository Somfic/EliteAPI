using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class KickCrewMemberInfo : IEvent
    {
        internal static KickCrewMemberInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeKickCrewMemberEvent(JsonConvert.DeserializeObject<KickCrewMemberInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Crew")]
        public string Crew { get; internal set; }
        [JsonProperty("OnCrime")]
        public bool OnCrime { get; internal set; }
    }
}
