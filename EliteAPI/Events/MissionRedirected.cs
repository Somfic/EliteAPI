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
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("MissionID")]
        public long MissionId { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("NewDestinationStation")]
        public string NewDestinationStation { get; set; }

        [JsonProperty("NewDestinationSystem")]
        public string NewDestinationSystem { get; set; }

        [JsonProperty("OldDestinationStation")]
        public string OldDestinationStation { get; set; }

        [JsonProperty("OldDestinationSystem")]
        public string OldDestinationSystem { get; set; }
    }

    public partial class MissionRedirectedInfo
    {
        public static MissionRedirectedInfo Process(string json) => EventHandler.InvokeMissionRedirectedEvent(JsonConvert.DeserializeObject<MissionRedirectedInfo>(json, EliteAPI.Events.MissionRedirectedConverter.Settings));
    }

    public static class MissionRedirectedSerializer
    {
        public static string ToJson(this MissionRedirectedInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.MissionRedirectedConverter.Settings);
    }

    internal static class MissionRedirectedConverter
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
