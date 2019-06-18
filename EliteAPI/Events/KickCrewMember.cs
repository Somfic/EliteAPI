namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class KickCrewMemberInfo : IEvent
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Crew")]
        public string Crew { get; internal set; }

        [JsonProperty("OnCrime")]
        public bool OnCrime { get; internal set; }
    }

    public partial class KickCrewMemberInfo
    {
        public static KickCrewMemberInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeKickCrewMemberEvent(JsonConvert.DeserializeObject<KickCrewMemberInfo>(json, EliteAPI.Events.KickCrewMemberConverter.Settings));
    }

    

    internal static class KickCrewMemberConverter
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
