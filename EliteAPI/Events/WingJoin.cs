namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class WingJoinInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Others")]
        public List<string> Others { get; internal set; }
    }

    public partial class WingJoinInfo
    {
        public static WingJoinInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeWingJoinEvent(JsonConvert.DeserializeObject<WingJoinInfo>(json, EliteAPI.Events.WingJoinConverter.Settings));
    }

    public static class WingJoinSerializer
    {
        public static string ToJson(this WingJoinInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.WingJoinConverter.Settings);
    }

    internal static class WingJoinConverter
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
