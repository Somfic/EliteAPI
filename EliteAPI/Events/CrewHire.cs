namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class CrewHireInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("CrewID")]
        public long CrewId { get; internal set; }

        [JsonProperty("Faction")]
        public string Faction { get; internal set; }

        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        [JsonProperty("CombatRank")]
        public long CombatRank { get; internal set; }
    }

    public partial class CrewHireInfo
    {
        public static CrewHireInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCrewHireEvent(JsonConvert.DeserializeObject<CrewHireInfo>(json, EliteAPI.Events.CrewHireConverter.Settings));
    }

    public static class CrewHireSerializer
    {
        public static string ToJson(this CrewHireInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.CrewHireConverter.Settings);
    }

    internal static class CrewHireConverter
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
