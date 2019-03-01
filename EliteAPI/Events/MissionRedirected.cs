namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class MissionRedirectedInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("MissionID")]
        public long MissionId { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("NewDestinationStation")]
        public string NewDestinationStation { get; internal set; }

        [JsonProperty("NewDestinationSystem")]
        public string NewDestinationSystem { get; internal set; }

        [JsonProperty("OldDestinationStation")]
        public string OldDestinationStation { get; internal set; }

        [JsonProperty("OldDestinationSystem")]
        public string OldDestinationSystem { get; internal set; }
    }

    public partial class MissionRedirectedInfo
    {
        public static MissionRedirectedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMissionRedirectedEvent(JsonConvert.DeserializeObject<MissionRedirectedInfo>(json, EliteAPI.Events.MissionRedirectedConverter.Settings));
    }

    public static class MissionRedirectedSerializer
    {
        public static string ToJson(this MissionRedirectedInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.MissionRedirectedConverter.Settings);
    }

    internal static class MissionRedirectedConverter
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
