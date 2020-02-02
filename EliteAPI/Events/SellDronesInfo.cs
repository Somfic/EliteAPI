using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class SellDronesInfo : EventBase
    {
        [JsonProperty("Type")]
        public string Type { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }

        [JsonProperty("SellPrice")]
        public long SellPrice { get; internal set; }

        [JsonProperty("TotalSale")]
        public long TotalSale { get; internal set; }

        internal static SellDronesInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeSellDronesEvent(JsonConvert.DeserializeObject<SellDronesInfo>(json, JsonSettings.Settings));
        }
    }
}