namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class USSDropInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("USSType")]
        public string UssType { get; internal set; }

        [JsonProperty("USSType_Localised")]
        public string UssTypeLocalised { get; internal set; }

        [JsonProperty("USSThreat")]
        public long UssThreat { get; internal set; }
    }

    public partial class USSDropInfo
    {
        public static USSDropInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeUSSDropEvent(JsonConvert.DeserializeObject<USSDropInfo>(json, EliteAPI.Events.USSDropConverter.Settings));
    }

    public static class USSDropSerializer
    {
        public static string ToJson(this USSDropInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.USSDropConverter.Settings);
    }

    internal static class USSDropConverter
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
