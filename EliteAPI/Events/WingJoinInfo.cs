using System;
using System.Collections.Generic;

namespace EliteAPI.Events
{
    using Newtonsoft.Json;

    public class WingJoinInfo : IEvent
    {
        internal static WingJoinInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeWingJoinEvent(JsonConvert.DeserializeObject<WingJoinInfo>(json, EliteAPI.Events.WingJoinConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Others")]
        public List<string> Others { get; internal set; }
    }
}
