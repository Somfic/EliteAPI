using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class PowerplayJoinInfo : IEvent
    {
        internal static PowerplayJoinInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokePowerplayJoinEvent(JsonConvert.DeserializeObject<PowerplayJoinInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Power")]
        public string Power { get; internal set; }
    }
}
