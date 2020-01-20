using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class QuitACrewInfo : EventBase
    {
        internal static QuitACrewInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeQuitACrewEvent(JsonConvert.DeserializeObject<QuitACrewInfo>(json, JsonSettings.Settings));

        [JsonProperty("Captain")]
        public string Captain { get; internal set; }
    }
}
