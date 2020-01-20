using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class DockingCancelledInfo : IEvent
    {
        internal static DockingCancelledInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeDockingCancelledEvent(JsonConvert.DeserializeObject<DockingCancelledInfo>(json, EliteAPI.Events.DockingCancelledConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }
        [JsonProperty("StationName")]
        public string StationName { get; internal set; }
        [JsonProperty("StationType")]
        public string StationType { get; internal set; }
    }
}
