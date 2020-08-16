using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class StoredShipsEvent : EventBase
    {
        internal StoredShipsEvent() { }

        public static StoredShipsEvent FromJson(string json) => JsonConvert.DeserializeObject<StoredShipsEvent>(json);


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