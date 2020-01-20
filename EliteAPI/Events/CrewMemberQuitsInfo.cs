using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class CrewMemberQuitsInfo : EventBase
    {
        internal static CrewMemberQuitsInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCrewMemberQuitsEvent(JsonConvert.DeserializeObject<CrewMemberQuitsInfo>(json, JsonSettings.Settings));

        [JsonProperty("Crew")]
        public string Crew { get; internal set; }
    }
}
