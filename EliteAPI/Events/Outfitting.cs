namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class OutfittingInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("StationName")]
        public string StationName { get; internal set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }
    }

    public partial class OutfittingInfo
    {
        public static OutfittingInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeOutfittingEvent(JsonConvert.DeserializeObject<OutfittingInfo>(json, EliteAPI.Events.OutfittingConverter.Settings));
    }

    public static class OutfittingSerializer
    {
        public static string ToJson(this OutfittingInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.OutfittingConverter.Settings);
    }

    internal static class OutfittingConverter
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
