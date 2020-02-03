using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class RepairDroneInfo : EventBase
    {
        [JsonProperty("HullRepaired")]
        public float HullRepaired { get; internal set; }

        [JsonProperty("CockpitRepaired")]
        public float CockpitRepaired { get; internal set; }

        internal static RepairDroneInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeRepairDroneEvent(JsonConvert.DeserializeObject<RepairDroneInfo>(json, JsonSettings.Settings));
        }
    }
}