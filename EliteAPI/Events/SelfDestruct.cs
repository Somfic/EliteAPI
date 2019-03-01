namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class SelfDestructInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }
    }

    public partial class SelfDestructInfo
    {
        public static SelfDestructInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeSelfDestructEvent(JsonConvert.DeserializeObject<SelfDestructInfo>(json, EliteAPI.Events.SelfDestructConverter.Settings));
    }

    public static class SelfDestructSerializer
    {
        public static string ToJson(this SelfDestructInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.SelfDestructConverter.Settings);
    }

    internal static class SelfDestructConverter
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
