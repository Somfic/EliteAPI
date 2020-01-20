using System;
using System.Collections.Generic;

namespace EliteAPI.Events
{
    using Newtonsoft.Json;

    public class CargoInfo : IEvent
    {
        internal static CargoInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCargoEvent(JsonConvert.DeserializeObject<CargoInfo>(json, EliteAPI.Events.CargoConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Vessel")]
        public string Vessel { get; internal set; }
        [JsonProperty("Count")]
        public long Count { get; internal set; }
        [JsonProperty("Inventory")]
        public List<Inventory> Inventory { get; internal set; }
    }
}
