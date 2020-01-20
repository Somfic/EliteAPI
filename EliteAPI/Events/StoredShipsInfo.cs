using System;
using System.Collections.Generic;

namespace EliteAPI.Events
{
    using Newtonsoft.Json;

    public class StoredShipsInfo : EventBase
    {
        internal static StoredShipsInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeStoredShipsEvent(JsonConvert.DeserializeObject<StoredShipsInfo>(json, JsonSettings.Settings));

        [JsonProperty("StationName")]
        public string StationName { get; internal set; }
        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }
        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }
        [JsonProperty("ShipsHere")]
        public List<object> ShipsHere { get; internal set; }
        [JsonProperty("ShipsRemote")]
        public List<ShipsRemote> ShipsRemote { get; internal set; }
    }
}
