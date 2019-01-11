namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ModuleSellInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; set; }

        [JsonProperty("Slot")]
        public string Slot { get; set; }

        [JsonProperty("SellItem")]
        public string SellItem { get; set; }

        [JsonProperty("SellItem_Localised")]
        public string SellItemLocalised { get; set; }

        [JsonProperty("SellPrice")]
        public long SellPrice { get; set; }

        [JsonProperty("Ship")]
        public string Ship { get; set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; set; }
    }

    public partial class ModuleSellInfo
    {
        public static ModuleSellInfo Process(string json, EliteDangerousAPI api) => api.EventHandler.InvokeModuleSellEvent(JsonConvert.DeserializeObject<ModuleSellInfo>(json, EliteAPI.Events.ModuleSellConverter.Settings));
    }

    public static class ModuleSellSerializer
    {
        public static string ToJson(this ModuleSellInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.ModuleSellConverter.Settings);
    }

    internal static class ModuleSellConverter
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
