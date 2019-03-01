namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ReputationInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Empire")]
        public double Empire { get; internal set; }

        [JsonProperty("Federation")]
        public double Federation { get; internal set; }

        [JsonProperty("Independent")]
        public double Independent { get; internal set; }

        [JsonProperty("Alliance")]
        public double Alliance { get; internal set; }
    }

    public partial class ReputationInfo
    {
        public static ReputationInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeReputationEvent(JsonConvert.DeserializeObject<ReputationInfo>(json, EliteAPI.Events.ReputationConverter.Settings));
    }

    public static class ReputationSerializer
    {
        public static string ToJson(this ReputationInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.ReputationConverter.Settings);
    }

    internal static class ReputationConverter
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
