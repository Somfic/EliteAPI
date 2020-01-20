using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class PowerplaySalaryInfo : EventBase
    {
        internal static PowerplaySalaryInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokePowerplaySalaryEvent(JsonConvert.DeserializeObject<PowerplaySalaryInfo>(json, JsonSettings.Settings));

        [JsonProperty("Power")]
        public string Power { get; internal set; }
        [JsonProperty("Amount")]
        public long Amount { get; internal set; }
    }
}
