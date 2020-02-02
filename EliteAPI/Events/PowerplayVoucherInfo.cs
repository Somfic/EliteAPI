using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class PowerplayVoucherInfo : EventBase
    {
        [JsonProperty("Power")]
        public string Power { get; internal set; }

        [JsonProperty("Systems")]
        public List<string> Systems { get; internal set; }

        internal static PowerplayVoucherInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokePowerplayVoucherEvent(JsonConvert.DeserializeObject<PowerplayVoucherInfo>(json, JsonSettings.Settings));
        }
    }
}