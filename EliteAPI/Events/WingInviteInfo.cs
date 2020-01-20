using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class WingInviteInfo : IEvent
    {
        internal static WingInviteInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeWingInviteEvent(JsonConvert.DeserializeObject<WingInviteInfo>(json, EliteAPI.Events.WingInviteConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Name")]
        public string Name { get; internal set; }
    }
}
