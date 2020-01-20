using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class RebootRepairInfo : EventBase
    {
        [JsonProperty("Modules")]
        public List<string> Modules { get; internal set; }

        internal static RebootRepairInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeRebootRepairEvent(JsonConvert.DeserializeObject<RebootRepairInfo>(json, JsonSettings.Settings));
        }
    }
}