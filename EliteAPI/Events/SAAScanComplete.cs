namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class SAAScanCompleteInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("BodyName")]
        public string BodyName { get; internal set; }

        [JsonProperty("BodyID")]
        public long BodyId { get; internal set; }

        [JsonProperty("ProbesUsed")]
        public long ProbesUsed { get; internal set; }

        [JsonProperty("EfficiencyTarget")]
        public long EfficiencyTarget { get; internal set; }
    }

    public partial class SAAScanCompleteInfo
    {
        public static SAAScanCompleteInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeSAAScanCompleteEvent(JsonConvert.DeserializeObject<SAAScanCompleteInfo>(json, EliteAPI.Events.SAAScanCompleteConverter.Settings));
    }

    public static class SAAScanCompleteSerializer
    {
        public static string ToJson(this SAAScanCompleteInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.SAAScanCompleteConverter.Settings);
    }

    internal static class SAAScanCompleteConverter
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
