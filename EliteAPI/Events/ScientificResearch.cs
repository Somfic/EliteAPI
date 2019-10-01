namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ScientificResearchInfo : IEvent
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Category")]
        public string Category { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }
    }

    public partial class ScientificResearchInfo
    {
        public static ScientificResearchInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeScientificResearchEvent(JsonConvert.DeserializeObject<ScientificResearchInfo>(json, EliteAPI.Events.ScientificResearchConverter.Settings));
    }

    

    internal static class ScientificResearchConverter
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
