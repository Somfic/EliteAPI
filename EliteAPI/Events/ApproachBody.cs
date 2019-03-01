namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ApproachBodyInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        [JsonProperty("Body")]
        public string Body { get; internal set; }

        [JsonProperty("BodyID")]
        public long BodyId { get; internal set; }
    }

    public partial class ApproachBodyInfo
    {
        public static ApproachBodyInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeApproachBodyEvent(JsonConvert.DeserializeObject<ApproachBodyInfo>(json, EliteAPI.Events.ApproachBodyConverter.Settings));
    }

    public static class ApproachBodySerializer
    {
        public static string ToJson(this ApproachBodyInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.ApproachBodyConverter.Settings);
    }

    internal static class ApproachBodyConverter
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
