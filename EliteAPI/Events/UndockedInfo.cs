using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class UndockedInfo : EventBase
    {
        [JsonProperty("StationName")]
        public string StationName { get; internal set; }

        [JsonProperty("StationType")]
        public string StationType { get; internal set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        internal static UndockedInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeUndockedEvent(JsonConvert.DeserializeObject<UndockedInfo>(json, JsonSettings.Settings));
        }
    }
}