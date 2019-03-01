namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class UndockedInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("StationName")]
        public string StationName { get; internal set; }

        [JsonProperty("StationType")]
        public string StationType { get; internal set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }
    }

    public partial class UndockedInfo
    {
        public static UndockedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeUndockedEvent(JsonConvert.DeserializeObject<UndockedInfo>(json, EliteAPI.Events.UndockedConverter.Settings));
    }

    public static class UndockedSerializer
    {
        public static string ToJson(this UndockedInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.UndockedConverter.Settings);
    }

    internal static class UndockedConverter
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
