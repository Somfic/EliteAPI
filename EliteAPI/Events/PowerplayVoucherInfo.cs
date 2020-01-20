using System;
using System.Collections.Generic;

namespace EliteAPI.Events
{
    using Newtonsoft.Json;

    public class PowerplayVoucherInfo : EventBase
    {
        internal static PowerplayVoucherInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokePowerplayVoucherEvent(JsonConvert.DeserializeObject<PowerplayVoucherInfo>(json, JsonSettings.Settings));

        [JsonProperty("Power")]
        public string Power { get; internal set; }
        [JsonProperty("Systems")]
        public List<string> Systems { get; internal set; }
    }
}
