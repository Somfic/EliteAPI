namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class MissionFailedInfo : IEvent
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

    public partial class MissionFailedInfo
    {
        public static MissionFailedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMissionFailedEvent(JsonConvert.DeserializeObject<MissionFailedInfo>(json, EliteAPI.Events.MissionFailedConverter.Settings));
    }

    

    internal static class MissionFailedConverter
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
