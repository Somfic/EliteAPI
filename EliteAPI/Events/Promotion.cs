namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class PromotionInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Federation")]
        public long Federation { get; set; }
    }

    public partial class PromotionInfo
    {
        public static PromotionInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokePromotionEvent(JsonConvert.DeserializeObject<PromotionInfo>(json, EliteAPI.Events.PromotionConverter.Settings));
    }

    public static class PromotionSerializer
    {
        public static string ToJson(this PromotionInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.PromotionConverter.Settings);
    }

    internal static class PromotionConverter
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
