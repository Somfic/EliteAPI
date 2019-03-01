namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ScannedInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("ScanType")]
        public string ScanType { get; internal set; }
    }

    public partial class ScannedInfo
    {
        public static ScannedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeScannedEvent(JsonConvert.DeserializeObject<ScannedInfo>(json, EliteAPI.Events.ScannedConverter.Settings));
    }

    public static class ScannedSerializer
    {
        public static string ToJson(this ScannedInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.ScannedConverter.Settings);
    }

    internal static class ScannedConverter
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
