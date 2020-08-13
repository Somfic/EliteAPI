using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EliteAPI.Event.Models.Travel
{
    public class DockingTimeoutEvent : EventBase
    {
        internal DockingTimeoutEvent() { }

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

        
    }
}