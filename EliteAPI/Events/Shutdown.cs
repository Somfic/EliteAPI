namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ShutdownInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }
    }

    public partial class ShutdownInfo
    {
        public static ShutdownInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeShutdownEvent(JsonConvert.DeserializeObject<ShutdownInfo>(json, EliteAPI.Events.ShutdownConverter.Settings));
    }

    public static class ShutdownSerializer
    {
        public static string ToJson(this ShutdownInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.ShutdownConverter.Settings);
    }

    internal static class ShutdownConverter
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
