using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class PowerplayDefectInfo : EventBase
    {
        internal static PowerplayDefectInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokePowerplayDefectEvent(JsonConvert.DeserializeObject<PowerplayDefectInfo>(json, JsonSettings.Settings));

        [JsonProperty("FromPower")]
        public string FromPower { get; internal set; }
        [JsonProperty("ToPower")]
        public string ToPower { get; internal set; }
    }
}
