using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class MarketInfo : EventBase
    {
        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("StationName")]
        public string StationName { get; internal set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        internal static MarketInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeMarketEvent(JsonConvert.DeserializeObject<MarketInfo>(json, JsonSettings.Settings));
        }
    }
}