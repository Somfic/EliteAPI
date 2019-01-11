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
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Crew")]
        public string Crew { get; set; }

        [JsonProperty("Role")]
        public string Role { get; set; }
    }

    public partial class CrewMemberRoleChangeInfo
    {
        public static CrewMemberRoleChangeInfo Process(string json, EliteDangerousAPI api) => api.EventHandler.InvokeCrewMemberRoleChangeEvent(JsonConvert.DeserializeObject<CrewMemberRoleChangeInfo>(json, EliteAPI.Events.CrewMemberRoleChangeConverter.Settings));
    }

    public static class CrewMemberRoleChangeSerializer
    {
        public static string ToJson(this CrewMemberRoleChangeInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.CrewMemberRoleChangeConverter.Settings);
    }

    internal static class CrewMemberRoleChangeConverter
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
