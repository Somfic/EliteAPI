using System;
using System.Collections.Generic;

namespace EliteAPI.Events
{
    using Newtonsoft.Json;

    public class PowerplayVoucherInfo : IEvent
    {
        internal static PowerplayVoucherInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokePowerplayVoucherEvent(JsonConvert.DeserializeObject<PowerplayVoucherInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Power")]
        public string Power { get; internal set; }
        [JsonProperty("Systems")]
        public List<string> Systems { get; internal set; }
    }
}
