using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class OutfittingInfo : EventBase
    {
        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("StationName")]
        public string StationName { get; internal set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        internal static OutfittingInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeOutfittingEvent(JsonConvert.DeserializeObject<OutfittingInfo>(json, JsonSettings.Settings));
        }
    }
}