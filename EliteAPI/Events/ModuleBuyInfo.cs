using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ModuleBuyInfo : IEvent
    {
        internal static ModuleBuyInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeModuleBuyEvent(JsonConvert.DeserializeObject<ModuleBuyInfo>(json, EliteAPI.Events.ModuleBuyConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Slot")]
        public string Slot { get; internal set; }
        [JsonProperty("SellItem")]
        public string SellItem { get; internal set; }
        [JsonProperty("SellItem_Localised")]
        public string SellItemLocalised { get; internal set; }
        [JsonProperty("SellPrice")]
        public long SellPrice { get; internal set; }
        [JsonProperty("BuyItem")]
        public string BuyItem { get; internal set; }
        [JsonProperty("BuyItem_Localised")]
        public string BuyItemLocalised { get; internal set; }
        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }
        [JsonProperty("BuyPrice")]
        public long BuyPrice { get; internal set; }
        [JsonProperty("Ship")]
        public string Ship { get; internal set; }
        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }
    }
}
