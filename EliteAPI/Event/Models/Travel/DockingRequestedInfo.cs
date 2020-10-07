using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EliteAPI.Event.Models.Travel
{
    public class DockingRequestedEvent : EventBase
    {
        internal DockingRequestedEvent() { }

        public static DockingRequestedEvent FromJson(string json) => JsonConvert.DeserializeObject<DockingRequestedEvent>(json);



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

        
    }
}