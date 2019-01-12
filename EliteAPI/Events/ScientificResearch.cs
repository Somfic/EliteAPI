namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ScientificResearchInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Category")]
        public string Category { get; set; }

        [JsonProperty("Count")]
        public long Count { get; set; }
    }

    public partial class ScientificResearchInfo
    {
        public static ScientificResearchInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeScientificResearchEvent(JsonConvert.DeserializeObject<ScientificResearchInfo>(json, EliteAPI.Events.ScientificResearchConverter.Settings));
    }

    public static class ScientificResearchSerializer
    {
        public static string ToJson(this ScientificResearchInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.ScientificResearchConverter.Settings);
    }

    internal static class ScientificResearchConverter
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
