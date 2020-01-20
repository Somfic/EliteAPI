using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class BuyDronesInfo : EventBase
    {
        [JsonProperty("Type")]
        public string Type { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }

        [JsonProperty("BuyPrice")]
        public long BuyPrice { get; internal set; }

        [JsonProperty("TotalCost")]
        public long TotalCost { get; internal set; }

        internal static BuyDronesInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeBuyDronesEvent(JsonConvert.DeserializeObject<BuyDronesInfo>(json, JsonSettings.Settings));
        }
    }
}