namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class EngineerContributionInfo : IEvent
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Engineer")]
        public string Engineer { get; internal set; }

        [JsonProperty("Type")]
        public string Type { get; internal set; }

        [JsonProperty("Material")]
        public string Material { get; internal set; }

        [JsonProperty("Quantity")]
        public long Quantity { get; internal set; }

        [JsonProperty("TotalQuantity")]
        public long TotalQuantity { get; internal set; }
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
            MissingMemberHandling = MissingMemberHandling.Ignore, MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
