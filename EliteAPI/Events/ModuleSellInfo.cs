using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class ModuleSellInfo : EventBase
    {
        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("Slot")]
        public string Slot { get; internal set; }

        [JsonProperty("SellItem")]
        public string SellItem { get; internal set; }

        [JsonProperty("SellItem_Localised")]
        public string SellItemLocalised { get; internal set; }

        [JsonProperty("SellPrice")]
        public long SellPrice { get; internal set; }

        [JsonProperty("Ship")]
        public string Ship { get; internal set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }

        internal static ModuleSellInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeModuleSellEvent(JsonConvert.DeserializeObject<ModuleSellInfo>(json, JsonSettings.Settings));
        }
    }
}