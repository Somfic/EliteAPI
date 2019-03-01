namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class CrewMemberRoleChangeInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Crew")]
        public string Crew { get; internal set; }

        [JsonProperty("Role")]
        public string Role { get; internal set; }
    }

    public partial class CrewMemberRoleChangeInfo
    {
        public static CrewMemberRoleChangeInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCrewMemberRoleChangeEvent(JsonConvert.DeserializeObject<CrewMemberRoleChangeInfo>(json, EliteAPI.Events.CrewMemberRoleChangeConverter.Settings));
    }

    public static class CrewMemberRoleChangeSerializer
    {
        public static string ToJson(this CrewMemberRoleChangeInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.CrewMemberRoleChangeConverter.Settings);
    }

    internal static class CrewMemberRoleChangeConverter
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
