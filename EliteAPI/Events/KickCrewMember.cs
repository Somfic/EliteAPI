namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class KickCrewMemberInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Crew")]
        public string Crew { get; set; }

        [JsonProperty("OnCrime")]
        public bool OnCrime { get; set; }
    }

    public partial class KickCrewMemberInfo
    {
        public static KickCrewMemberInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeKickCrewMemberEvent(JsonConvert.DeserializeObject<KickCrewMemberInfo>(json, EliteAPI.Events.KickCrewMemberConverter.Settings));
    }

    public static class KickCrewMemberSerializer
    {
        public static string ToJson(this KickCrewMemberInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.KickCrewMemberConverter.Settings);
    }

    internal static class KickCrewMemberConverter
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
