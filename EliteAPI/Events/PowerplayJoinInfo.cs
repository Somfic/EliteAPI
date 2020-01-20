using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class PowerplayJoinInfo : EventBase
    {
        internal static PowerplayJoinInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokePowerplayJoinEvent(JsonConvert.DeserializeObject<PowerplayJoinInfo>(json, JsonSettings.Settings));

        [JsonProperty("Power")]
        public string Power { get; internal set; }
    }
}
