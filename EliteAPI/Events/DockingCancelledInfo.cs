using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class DockingCancelledInfo : EventBase
    {
        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("StationName")]
        public string StationName { get; internal set; }

        [JsonProperty("StationType")]
        public string StationType { get; internal set; }

        internal static DockingCancelledInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeDockingCancelledEvent(JsonConvert.DeserializeObject<DockingCancelledInfo>(json, JsonSettings.Settings));
        }
    }
}