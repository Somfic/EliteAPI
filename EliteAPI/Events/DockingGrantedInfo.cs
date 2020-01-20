using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class DockingGrantedInfo : EventBase
    {
        [JsonProperty("LandingPad")]
        public long LandingPad { get; internal set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("StationName")]
        public string StationName { get; internal set; }

        [JsonProperty("StationType")]
        public string StationType { get; internal set; }

        internal static DockingGrantedInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeDockingGrantedEvent(JsonConvert.DeserializeObject<DockingGrantedInfo>(json, JsonSettings.Settings));
        }
    }
}