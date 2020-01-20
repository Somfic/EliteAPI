using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class EndCrewSessionInfo : EventBase
    {
        internal static EndCrewSessionInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeEndCrewSessionEvent(JsonConvert.DeserializeObject<EndCrewSessionInfo>(json, JsonSettings.Settings));

        [JsonProperty("OnCrime")]
        public bool OnCrime { get; internal set; }
    }
}
