using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ModuleSellInfo : EventBase
    {
        internal static ModuleSellInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeModuleSellEvent(JsonConvert.DeserializeObject<ModuleSellInfo>(json, JsonSettings.Settings));

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
    }
}
