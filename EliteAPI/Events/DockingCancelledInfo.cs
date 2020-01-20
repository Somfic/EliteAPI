using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class DockingCancelledInfo : EventBase
    {
        internal static DockingCancelledInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeDockingCancelledEvent(JsonConvert.DeserializeObject<DockingCancelledInfo>(json, JsonSettings.Settings));

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }
        [JsonProperty("StationName")]
        public string StationName { get; internal set; }
        [JsonProperty("StationType")]
        public string StationType { get; internal set; }
    }
}
