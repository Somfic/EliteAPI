using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class PowerplayLeaveInfo : EventBase
    {
        internal static PowerplayLeaveInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokePowerplayLeaveEvent(JsonConvert.DeserializeObject<PowerplayLeaveInfo>(json, JsonSettings.Settings));

        [JsonProperty("Power")]
        public string Power { get; internal set; }
    }
}
