using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class RefuelAllInfo : IEvent
    {
        internal static RefuelAllInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeRefuelAllEvent(JsonConvert.DeserializeObject<RefuelAllInfo>(json, EliteAPI.Events.RefuelAllConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Cost")]
        public long Cost { get; internal set; }
        [JsonProperty("Amount")]
        public double Amount { get; internal set; }
    }
}
