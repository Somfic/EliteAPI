using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class JoinACrewInfo : EventBase
    {
        internal static JoinACrewInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeJoinACrewEvent(JsonConvert.DeserializeObject<JoinACrewInfo>(json, JsonSettings.Settings));

        [JsonProperty("Captain")]
        public string Captain { get; internal set; }
    }
}
