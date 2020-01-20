using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class WingAddInfo : IEvent
    {
        internal static WingAddInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeWingAddEvent(JsonConvert.DeserializeObject<WingAddInfo>(json, EliteAPI.Events.WingAddConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Name")]
        public string Name { get; internal set; }
    }
}
