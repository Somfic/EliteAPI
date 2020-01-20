using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ShipyardNewInfo : IEvent
    {
        internal static ShipyardNewInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeShipyardNewEvent(JsonConvert.DeserializeObject<ShipyardNewInfo>(json, EliteAPI.Events.ShipyardNewConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("ShipType")]
        public string ShipType { get; internal set; }
        [JsonProperty("ShipType_Localised")]
        public string ShipTypeLocalised { get; internal set; }
        [JsonProperty("NewShipID")]
        public long NewShipId { get; internal set; }
    }
}
