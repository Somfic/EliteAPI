using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class BuyTradeDataInfo : EventBase
    {
        [JsonProperty("System")]
        public string System { get; internal set; }

        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        internal static BuyTradeDataInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeBuyTradeDataEvent(JsonConvert.DeserializeObject<BuyTradeDataInfo>(json, JsonSettings.Settings));
        }
    }
}