using System;
using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class RepairDroneInfo : EventBase
    {
        internal static RepairDroneInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeRepairDroneEvent(JsonConvert.DeserializeObject<RepairDroneInfo>(json, JsonSettings.Settings));

        [JsonProperty("HullRepaired")]
        public double HullRepaired { get; internal set; }
        [JsonProperty("CockpitRepaired")]
        public double CockpitRepaired { get; internal set; }
    }
}