namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class BuyTradeDataInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("System")]
        public string System { get; internal set; }

        [JsonProperty("Cost")]
        public long Cost { get; internal set; }
    }

    public partial class BuyTradeDataInfo
    {
        public static BuyTradeDataInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeBuyTradeDataEvent(JsonConvert.DeserializeObject<BuyTradeDataInfo>(json, EliteAPI.Events.BuyTradeDataConverter.Settings));
    }

    public static class BuyTradeDataSerializer
    {
        public static string ToJson(this BuyTradeDataInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.BuyTradeDataConverter.Settings);
    }

    internal static class BuyTradeDataConverter
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
