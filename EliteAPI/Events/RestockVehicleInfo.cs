using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class RestockVehicleInfo : EventBase
    {
        internal static RestockVehicleInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeRestockVehicleEvent(JsonConvert.DeserializeObject<RestockVehicleInfo>(json, JsonSettings.Settings));

        [JsonProperty("Type")]
        public string Type { get; internal set; }
        [JsonProperty("Loadout")]
        public string Loadout { get; internal set; }
        [JsonProperty("Cost")]
        public long Cost { get; internal set; }
        [JsonProperty("Count")]
        public long Count { get; internal set; }
    }
}
