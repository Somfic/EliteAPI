namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class MaterialTradeInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; set; }

        [JsonProperty("TraderType")]
        public string TraderType { get; set; }

        [JsonProperty("Paid")]
        public Paid Paid { get; set; }

        [JsonProperty("Received")]
        public Paid Received { get; set; }
    }

    public partial class Paid
    {
        [JsonProperty("Material")]
        public string Material { get; set; }

        [JsonProperty("Material_Localised")]
        public string MaterialLocalised { get; set; }

        [JsonProperty("Category")]
        public string Category { get; set; }

        [JsonProperty("Category_Localised")]
        public string CategoryLocalised { get; set; }

        [JsonProperty("Quantity")]
        public long Quantity { get; set; }
    }

    public partial class MaterialTradeInfo
    {
        public static MaterialTradeInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMaterialTradeEvent(JsonConvert.DeserializeObject<MaterialTradeInfo>(json, EliteAPI.Events.MaterialTradeConverter.Settings));
    }

    public static class MaterialTradeSerializer
    {
        public static string ToJson(this MaterialTradeInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.MaterialTradeConverter.Settings);
    }

    internal static class MaterialTradeConverter
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
