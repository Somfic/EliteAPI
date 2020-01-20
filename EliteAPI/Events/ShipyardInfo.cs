using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class ShipyardInfo : EventBase
    {
        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("StationName")]
        public string StationName { get; internal set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        internal static ShipyardInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeShipyardEvent(JsonConvert.DeserializeObject<ShipyardInfo>(json, JsonSettings.Settings));
        }
    }
}