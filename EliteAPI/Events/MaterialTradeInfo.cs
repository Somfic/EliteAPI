using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class MaterialTradeInfo : EventBase
    {
        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("TraderType")]
        public string TraderType { get; internal set; }

        [JsonProperty("Paid")]
        public Paid Paid { get; internal set; }

        [JsonProperty("Received")]
        public Paid Received { get; internal set; }

        internal static MaterialTradeInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeMaterialTradeEvent(JsonConvert.DeserializeObject<MaterialTradeInfo>(json, JsonSettings.Settings));
        }
    }
}