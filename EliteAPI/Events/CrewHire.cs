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
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("CrewID")]
        public long CrewId { get; set; }

        [JsonProperty("Faction")]
        public string Faction { get; set; }

        [JsonProperty("Cost")]
        public long Cost { get; set; }

        [JsonProperty("CombatRank")]
        public long CombatRank { get; set; }
    }

    public partial class CrewHireInfo
    {
        public static CrewHireInfo Process(string json) => EventHandler.InvokeCrewHireEvent(JsonConvert.DeserializeObject<CrewHireInfo>(json, EliteAPI.Events.CrewHireConverter.Settings));
    }

    public static class CrewHireSerializer
    {
        public static string ToJson(this CrewHireInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.CrewHireConverter.Settings);
    }

    internal static class CrewHireConverter
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
