using System;
using System.Collections.Generic;

namespace EliteAPI.Events
{
    using Newtonsoft.Json;

    public class CargoInfo : EventBase
    {
        internal static CargoInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCargoEvent(JsonConvert.DeserializeObject<CargoInfo>(json, JsonSettings.Settings));

        [JsonProperty("Vessel")]
        public string Vessel { get; internal set; }
        [JsonProperty("Count")]
        public long Count { get; internal set; }
        [JsonProperty("Inventory")]
        public List<Inventory> Inventory { get; internal set; }
    }
}
