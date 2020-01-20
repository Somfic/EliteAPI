using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class DockingDeniedInfo : IEvent
    {
        internal static DockingDeniedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeDockingDeniedEvent(JsonConvert.DeserializeObject<DockingDeniedInfo>(json, EliteAPI.Events.DockingDeniedConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Reason")]
        public string Reason { get; internal set; }
        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }
        [JsonProperty("StationName")]
        public string StationName { get; internal set; }
        [JsonProperty("StationType")]
        public string StationType { get; internal set; }
    }
}
