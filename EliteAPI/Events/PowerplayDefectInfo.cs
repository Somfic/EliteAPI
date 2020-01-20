using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class PowerplayDefectInfo : IEvent
    {
        internal static PowerplayDefectInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokePowerplayDefectEvent(JsonConvert.DeserializeObject<PowerplayDefectInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("FromPower")]
        public string FromPower { get; internal set; }
        [JsonProperty("ToPower")]
        public string ToPower { get; internal set; }
    }
}
