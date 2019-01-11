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
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("part")]
        public long Part { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("gameversion")]
        public string Gameversion { get; set; }

        [JsonProperty("build")]
        public string Build { get; set; }
    }

    public partial class FileheaderInfo
    {
        public static FileheaderInfo Process(string json, EliteDangerousAPI api) => api.EventHandler.InvokeFileheaderEvent(JsonConvert.DeserializeObject<FileheaderInfo>(json, EliteAPI.Events.FileheaderConverter.Settings));
    }

    public static class FileheaderSerializer
    {
        public static string ToJson(this FileheaderInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.FileheaderConverter.Settings);
    }

    internal static class FileheaderConverter
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
