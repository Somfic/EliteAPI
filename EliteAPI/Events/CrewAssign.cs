namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class CrewAssignInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("CrewID")]
        public long CrewId { get; set; }

        [JsonProperty("Role")]
        public string Role { get; set; }
    }

    public partial class CrewAssignInfo
    {
        public static CrewAssignInfo Process(string json, EliteDangerousAPI api) => api.EventHandler.InvokeCrewAssignEvent(JsonConvert.DeserializeObject<CrewAssignInfo>(json, EliteAPI.Events.CrewAssignConverter.Settings));
    }

    public static class CrewAssignSerializer
    {
        public static string ToJson(this CrewAssignInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.CrewAssignConverter.Settings);
    }

    internal static class CrewAssignConverter
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
