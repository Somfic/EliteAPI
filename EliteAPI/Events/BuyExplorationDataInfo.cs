using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class BuyExplorationDataInfo : EventBase
    {
        [JsonProperty("System")]
        public string System { get; internal set; }

        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        internal static BuyExplorationDataInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeBuyExplorationDataEvent(JsonConvert.DeserializeObject<BuyExplorationDataInfo>(json, JsonSettings.Settings));
        }
    }
}