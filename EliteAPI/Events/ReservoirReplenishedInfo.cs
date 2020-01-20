using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ReservoirReplenishedInfo : IEvent
    {
        internal static ReservoirReplenishedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeReservoirReplenishedEvent(JsonConvert.DeserializeObject<ReservoirReplenishedInfo>(json, EliteAPI.Events.ReservoirReplenishedConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }
        [JsonProperty("event")]
        public string Event { get; set; }
        [JsonProperty("FuelMain")]
        public double FuelMain { get; set; }
        [JsonProperty("FuelReservoir")]
        public double FuelReservoir { get; set; }
    }
}
