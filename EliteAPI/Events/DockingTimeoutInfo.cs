using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class DockingTimeoutInfo : EventBase
    {
        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("StationName")]
        public string StationName { get; internal set; }

        [JsonProperty("StationType")]
        public string StationType { get; internal set; }

        internal static DockingTimeoutInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeDockingTimeoutEvent(JsonConvert.DeserializeObject<DockingTimeoutInfo>(json, JsonSettings.Settings));
        }
    }
}