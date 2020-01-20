using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class DockingDeniedInfo : EventBase
    {
        [JsonProperty("Reason")]
        public string Reason { get; internal set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("StationName")]
        public string StationName { get; internal set; }

        [JsonProperty("StationType")]
        public string StationType { get; internal set; }

        internal static DockingDeniedInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeDockingDeniedEvent(JsonConvert.DeserializeObject<DockingDeniedInfo>(json, JsonSettings.Settings));
        }
    }
}