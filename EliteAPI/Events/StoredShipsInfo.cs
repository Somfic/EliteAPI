using System;
using System.Collections.Generic;

namespace EliteAPI.Events
{
    using Newtonsoft.Json;

    public class StoredShipsInfo : IEvent
    {
        internal static StoredShipsInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeStoredShipsEvent(JsonConvert.DeserializeObject<StoredShipsInfo>(json, EliteAPI.Events.StoredShipsConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
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
