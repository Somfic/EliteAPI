using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class DockingRequestedInfo : EventBase
    {
        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("StationName")]
        public string StationName { get; internal set; }

        [JsonProperty("StationType")]
        public string StationType { get; internal set; }

        internal static DockingRequestedInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeDockingRequestedEvent(JsonConvert.DeserializeObject<DockingRequestedInfo>(json, JsonSettings.Settings));
        }
    }
}