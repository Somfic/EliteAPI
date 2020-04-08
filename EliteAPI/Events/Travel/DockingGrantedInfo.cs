using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EliteAPI.Events.Travel
{
    public class DockingGrantedInfo : EventBase
    {
        internal DockingGrantedInfo() { }

        /// <summary>
        /// The pad number.
        /// </summary>
        [JsonProperty("LandingPad")]
        public int LandingPad { get; internal set; }

        /// <summary>
        /// The id of the station.
        /// </summary>
        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        /// <summary>
        /// The name of the station.
        /// </summary>
        [JsonProperty("StationName")]
        public string StationName { get; internal set; }

        /// <summary>
        /// The type of station.
        /// </summary>
        [JsonProperty("StationType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public StationType StationType { get; internal set; }

        internal static DockingGrantedInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeDockingGrantedEvent(JsonConvert.DeserializeObject<DockingGrantedInfo>(json, JsonSettings.Settings));
        }
    }
}