using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class SetUserShipNameInfo : IEvent
    {
        internal static SetUserShipNameInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeSetUserShipNameEvent(JsonConvert.DeserializeObject<SetUserShipNameInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Ship")]
        public string Ship { get; internal set; }
        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }
        [JsonProperty("UserShipName")]
        public string UserShipName { get; internal set; }
        [JsonProperty("UserShipId")]
        public string UserShipId { get; internal set; }
    }
}
