using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class UndockedInfo : IEvent
    {
        internal static UndockedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeUndockedEvent(JsonConvert.DeserializeObject<UndockedInfo>(json, EliteAPI.Events.UndockedConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("StationName")]
        public string StationName { get; internal set; }
        [JsonProperty("StationType")]
        public string StationType { get; internal set; }
        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }
    }
}
