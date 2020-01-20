using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class StoredShipsInfo : EventBase
    {
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

        internal static StoredShipsInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeStoredShipsEvent(JsonConvert.DeserializeObject<StoredShipsInfo>(json, JsonSettings.Settings));
        }
    }
}