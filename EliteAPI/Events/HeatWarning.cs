namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class HeatWarningInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }
    }

    public partial class HeatWarningInfo
    {
        public static HeatWarningInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeHeatWarningEvent(JsonConvert.DeserializeObject<HeatWarningInfo>(json, EliteAPI.Events.HeatWarningConverter.Settings));
    }

    public static class HeatWarningSerializer
    {
        public static string ToJson(this HeatWarningInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.HeatWarningConverter.Settings);
    }

    internal static class HeatWarningConverter
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
