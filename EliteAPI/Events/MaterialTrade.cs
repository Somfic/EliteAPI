namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class MaterialTradeInfo : IEvent
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("TraderType")]
        public string TraderType { get; internal set; }

        [JsonProperty("Paid")]
        public Paid Paid { get; internal set; }

        [JsonProperty("Received")]
        public Paid Received { get; internal set; }
    }

    public partial class Paid
    {
        [JsonProperty("Material")]
        public string Material { get; internal set; }

        [JsonProperty("Material_Localised")]
        public string MaterialLocalised { get; internal set; }

        [JsonProperty("Category")]
        public string Category { get; internal set; }

        [JsonProperty("Category_Localised")]
        public string CategoryLocalised { get; internal set; }

        [JsonProperty("Quantity")]
        public long Quantity { get; internal set; }
    }

    public partial class MaterialTradeInfo
    {
        public static MaterialTradeInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMaterialTradeEvent(JsonConvert.DeserializeObject<MaterialTradeInfo>(json, EliteAPI.Events.MaterialTradeConverter.Settings));
    }

    

    internal static class MaterialTradeConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MissingMemberHandling = MissingMemberHandling.Ignore, MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
