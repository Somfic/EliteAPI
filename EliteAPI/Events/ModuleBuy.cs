namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ModuleBuyInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Slot")]
        public string Slot { get; set; }

        [JsonProperty("SellItem")]
        public string SellItem { get; set; }

        [JsonProperty("SellItem_Localised")]
        public string SellItemLocalised { get; set; }

        [JsonProperty("SellPrice")]
        public long SellPrice { get; set; }

        [JsonProperty("BuyItem")]
        public string BuyItem { get; set; }

        [JsonProperty("BuyItem_Localised")]
        public string BuyItemLocalised { get; set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; set; }

        [JsonProperty("BuyPrice")]
        public long BuyPrice { get; set; }

        [JsonProperty("Ship")]
        public string Ship { get; set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; set; }
    }

    public partial class ModuleBuyInfo
    {
        public static ModuleBuyInfo Process(string json) => EventHandler.InvokeModuleBuyEvent(JsonConvert.DeserializeObject<ModuleBuyInfo>(json, EliteAPI.Events.ModuleBuyConverter.Settings));
    }

    public static class ModuleBuySerializer
    {
        public static string ToJson(this ModuleBuyInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.ModuleBuyConverter.Settings);
    }

    internal static class ModuleBuyConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
