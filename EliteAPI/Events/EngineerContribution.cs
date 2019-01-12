namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class EngineerContributionInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Engineer")]
        public string Engineer { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Material")]
        public string Material { get; set; }

        [JsonProperty("Quantity")]
        public long Quantity { get; set; }

        [JsonProperty("TotalQuantity")]
        public long TotalQuantity { get; set; }
    }

    public partial class EngineerContributionInfo
    {
        public static EngineerContributionInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeEngineerContributionEvent(JsonConvert.DeserializeObject<EngineerContributionInfo>(json, EliteAPI.Events.EngineerContributionConverter.Settings));
    }

    public static class EngineerContributionSerializer
    {
        public static string ToJson(this EngineerContributionInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.EngineerContributionConverter.Settings);
    }

    internal static class EngineerContributionConverter
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
