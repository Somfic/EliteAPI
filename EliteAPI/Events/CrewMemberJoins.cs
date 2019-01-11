namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class CrewMemberJoinsInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Crew")]
        public string Crew { get; set; }
    }

    public partial class CrewMemberJoinsInfo
    {
        public static CrewMemberJoinsInfo Process(string json, EliteDangerousAPI api) => api.EventHandler.InvokeCrewMemberJoinsEvent(JsonConvert.DeserializeObject<CrewMemberJoinsInfo>(json, EliteAPI.Events.CrewMemberJoinsConverter.Settings));
    }

    public static class CrewMemberJoinsSerializer
    {
        public static string ToJson(this CrewMemberJoinsInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.CrewMemberJoinsConverter.Settings);
    }

    internal static class CrewMemberJoinsConverter
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
