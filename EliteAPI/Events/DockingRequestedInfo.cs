using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class DockingRequestedInfo : EventBase
    {
        internal static DockingRequestedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeDockingRequestedEvent(JsonConvert.DeserializeObject<DockingRequestedInfo>(json, JsonSettings.Settings));

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }
        [JsonProperty("StationName")]
        public string StationName { get; internal set; }
        [JsonProperty("StationType")]
        public string StationType { get; internal set; }
    }
}
