namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class FileheaderInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("part")]
        public long Part { get; internal set; }

        [JsonProperty("language")]
        public string Language { get; internal set; }

        [JsonProperty("gameversion")]
        public string Gameversion { get; internal set; }

        [JsonProperty("build")]
        public string Build { get; internal set; }
    }

    public partial class FileheaderInfo
    {
        public static FileheaderInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeFileheaderEvent(JsonConvert.DeserializeObject<FileheaderInfo>(json, EliteAPI.Events.FileheaderConverter.Settings));
    }

    public static class FileheaderSerializer
    {
        public static string ToJson(this FileheaderInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.FileheaderConverter.Settings);
    }

    internal static class FileheaderConverter
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
