namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class EndCrewSessionInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("OnCrime")]
        public bool OnCrime { get; internal set; }
    }

    public partial class EndCrewSessionInfo
    {
        public static EndCrewSessionInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeEndCrewSessionEvent(JsonConvert.DeserializeObject<EndCrewSessionInfo>(json, EliteAPI.Events.EndCrewSessionConverter.Settings));
    }

    public static class EndCrewSessionSerializer
    {
        public static string ToJson(this EndCrewSessionInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.EndCrewSessionConverter.Settings);
    }

    internal static class EndCrewSessionConverter
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
