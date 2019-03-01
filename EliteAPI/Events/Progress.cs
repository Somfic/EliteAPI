namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ProgressInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Combat")]
        public long Combat { get; internal set; }

        [JsonProperty("Trade")]
        public long Trade { get; internal set; }

        [JsonProperty("Explore")]
        public long Explore { get; internal set; }

        [JsonProperty("Empire")]
        public long Empire { get; internal set; }

        [JsonProperty("Federation")]
        public long Federation { get; internal set; }

        [JsonProperty("CQC")]
        public long Cqc { get; internal set; }
    }

    public partial class ProgressInfo
    {
        public static ProgressInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeProgressEvent(JsonConvert.DeserializeObject<ProgressInfo>(json, EliteAPI.Events.ProgressConverter.Settings));
    }

    public static class ProgressSerializer
    {
        public static string ToJson(this ProgressInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.ProgressConverter.Settings);
    }

    internal static class ProgressConverter
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
