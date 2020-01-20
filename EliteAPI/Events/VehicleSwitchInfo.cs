using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class VehicleSwitchInfo : IEvent
    {
        internal static VehicleSwitchInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeVehicleSwitchEvent(JsonConvert.DeserializeObject<VehicleSwitchInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("To")]
        public string To { get; internal set; }
    }
}
