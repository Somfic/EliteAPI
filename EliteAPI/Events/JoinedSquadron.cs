namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class JoinedSquadronInfo : IEvent
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("SquadronName")]
        public string SquadronName { get; internal set; }
    }

    public partial class JoinedSquadronInfo
    {
        public static JoinedSquadronInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeJoinedSquadronEvent(JsonConvert.DeserializeObject<JoinedSquadronInfo>(json, EliteAPI.Events.JoinedSquadronConverter.Settings));
    }

    public static class JoinedSquadronSerializer
    {
        public static string ToJson(this JoinedSquadronInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.JoinedSquadronConverter.Settings);
    }

    internal static class JoinedSquadronConverter
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
