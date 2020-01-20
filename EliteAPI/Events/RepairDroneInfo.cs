using System;
using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class RepairDroneInfo : IEvent
    {
        internal static RepairDroneInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeRepairDroneEvent(JsonConvert.DeserializeObject<RepairDroneInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("HullRepaired")]
        public double HullRepaired { get; internal set; }
        [JsonProperty("CockpitRepaired")]
        public double CockpitRepaired { get; internal set; }
    }
}