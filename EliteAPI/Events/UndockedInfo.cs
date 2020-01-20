using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class UndockedInfo : EventBase
    {
        internal static UndockedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeUndockedEvent(JsonConvert.DeserializeObject<UndockedInfo>(json, JsonSettings.Settings));

        [JsonProperty("StationName")]
        public string StationName { get; internal set; }
        [JsonProperty("StationType")]
        public string StationType { get; internal set; }
        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }
    }
}
