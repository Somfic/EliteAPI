using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class PowerplayLeaveInfo : IEvent
    {
        internal static PowerplayLeaveInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokePowerplayLeaveEvent(JsonConvert.DeserializeObject<PowerplayLeaveInfo>(json, EliteAPI.Events.PowerplayLeaveConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Power")]
        public string Power { get; internal set; }
    }
}
