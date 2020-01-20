using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ShipyardNewInfo : EventBase
    {
        internal static ShipyardNewInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeShipyardNewEvent(JsonConvert.DeserializeObject<ShipyardNewInfo>(json, JsonSettings.Settings));

        [JsonProperty("ShipType")]
        public string ShipType { get; internal set; }
        [JsonProperty("ShipType_Localised")]
        public string ShipTypeLocalised { get; internal set; }
        [JsonProperty("NewShipID")]
        public long NewShipId { get; internal set; }
    }
}
