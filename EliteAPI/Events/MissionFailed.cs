namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class MissionFailedInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("MissionID")]
        public long MissionId { get; set; }
    }

    public partial class MissionFailedInfo
    {
        public static MissionFailedInfo Process(string json, EliteDangerousAPI api) => api.EventHandler.InvokeMissionFailedEvent(JsonConvert.DeserializeObject<MissionFailedInfo>(json, EliteAPI.Events.MissionFailedConverter.Settings));
    }

    public static class MissionFailedSerializer
    {
        public static string ToJson(this MissionFailedInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.MissionFailedConverter.Settings);
    }

    internal static class MissionFailedConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
