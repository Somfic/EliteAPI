using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EliteAPI.Events.Travel
{
    public class DockingRequestedInfo : EventBase
    {
        internal DockingRequestedInfo() { }

        /// <summary>
        /// The id of the market.
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

        internal static DockingRequestedInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeDockingRequestedEvent(JsonConvert.DeserializeObject<DockingRequestedInfo>(json, JsonSettings.Settings));
        }
    }
}