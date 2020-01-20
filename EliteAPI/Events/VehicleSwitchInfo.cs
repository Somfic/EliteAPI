using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class VehicleSwitchInfo : EventBase
    {
        internal static VehicleSwitchInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeVehicleSwitchEvent(JsonConvert.DeserializeObject<VehicleSwitchInfo>(json, JsonSettings.Settings));

        [JsonProperty("To")]
        public string To { get; internal set; }
    }
}
