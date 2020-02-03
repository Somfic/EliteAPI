using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class RefuelAllInfo : EventBase
    {
        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        [JsonProperty("Amount")]
        public float Amount { get; internal set; }

        internal static RefuelAllInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeRefuelAllEvent(JsonConvert.DeserializeObject<RefuelAllInfo>(json, JsonSettings.Settings));
        }
    }
}