namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class MissionAbandonedInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("MissionID")]
        public long MissionId { get; internal set; }
    }

    public partial class MissionAbandonedInfo
    {
        public static MissionAbandonedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMissionAbandonedEvent(JsonConvert.DeserializeObject<MissionAbandonedInfo>(json, EliteAPI.Events.MissionAbandonedConverter.Settings));
    }

    public static class MissionAbandonedSerializer
    {
        public static string ToJson(this MissionAbandonedInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.MissionAbandonedConverter.Settings);
    }

    internal static class MissionAbandonedConverter
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
