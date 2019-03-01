namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class FSSAllBodiesFoundInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("SystemName")]
        public string SystemName { get; internal set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }
    }

    public partial class FSSAllBodiesFoundInfo
    {
        public static FSSAllBodiesFoundInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeFSSAllBodiesFoundEvent(JsonConvert.DeserializeObject<FSSAllBodiesFoundInfo>(json, EliteAPI.Events.FSSAllBodiesFoundConverter.Settings));
    }

    public static class FSSAllBodiesFoundSerializer
    {
        public static string ToJson(this FSSAllBodiesFoundInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.FSSAllBodiesFoundConverter.Settings);
    }

    internal static class FSSAllBodiesFoundConverter
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
