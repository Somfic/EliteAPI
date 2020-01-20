using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class PowerplaySalaryInfo : IEvent
    {
        internal static PowerplaySalaryInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokePowerplaySalaryEvent(JsonConvert.DeserializeObject<PowerplaySalaryInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Power")]
        public string Power { get; internal set; }
        [JsonProperty("Amount")]
        public long Amount { get; internal set; }
    }
}
