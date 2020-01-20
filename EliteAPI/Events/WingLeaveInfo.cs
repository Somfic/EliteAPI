using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class WingLeaveInfo : IEvent
    {
        internal static WingLeaveInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeWingLeaveEvent(JsonConvert.DeserializeObject<WingLeaveInfo>(json, EliteAPI.Events.WingLeaveConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
    }
}
