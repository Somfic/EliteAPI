using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class OutfittingInfo : EventBase
    {
        internal static OutfittingInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeOutfittingEvent(JsonConvert.DeserializeObject<OutfittingInfo>(json, JsonSettings.Settings));

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }
        [JsonProperty("StationName")]
        public string StationName { get; internal set; }
        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }
    }
}
