namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class CrewMemberQuitsInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Crew")]
        public string Crew { get; set; }
    }

    public partial class CrewMemberQuitsInfo
    {
        public static CrewMemberQuitsInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCrewMemberQuitsEvent(JsonConvert.DeserializeObject<CrewMemberQuitsInfo>(json, EliteAPI.Events.CrewMemberQuitsConverter.Settings));
    }

    public static class CrewMemberQuitsSerializer
    {
        public static string ToJson(this CrewMemberQuitsInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.CrewMemberQuitsConverter.Settings);
    }

    internal static class CrewMemberQuitsConverter
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
