using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class KickCrewMemberInfo : EventBase
    {
        internal static KickCrewMemberInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeKickCrewMemberEvent(JsonConvert.DeserializeObject<KickCrewMemberInfo>(json, JsonSettings.Settings));

        [JsonProperty("Crew")]
        public string Crew { get; internal set; }
        [JsonProperty("OnCrime")]
        public bool OnCrime { get; internal set; }
    }
}
