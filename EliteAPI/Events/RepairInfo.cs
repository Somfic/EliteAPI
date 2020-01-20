using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class RepairInfo : EventBase
    {
        [JsonProperty("Item")]
        public string Item { get; internal set; }

        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        internal static RepairInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeRepairEvent(JsonConvert.DeserializeObject<RepairInfo>(json, JsonSettings.Settings));
        }
    }
}