using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class RepairAllInfo : EventBase
    {
        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        internal static RepairAllInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeRepairAllEvent(JsonConvert.DeserializeObject<RepairAllInfo>(json, JsonSettings.Settings));
        }
    }
}