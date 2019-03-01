namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class CrewFireInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("CrewID")]
        public long CrewId { get; internal set; }
    }

    public partial class CrewFireInfo
    {
        public static CrewFireInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCrewFireEvent(JsonConvert.DeserializeObject<CrewFireInfo>(json, EliteAPI.Events.CrewFireConverter.Settings));
    }

    public static class CrewFireSerializer
    {
        public static string ToJson(this CrewFireInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.CrewFireConverter.Settings);
    }

    internal static class CrewFireConverter
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
