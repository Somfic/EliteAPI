namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class SearchAndRescueInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Count")]
        public long Count { get; set; }

        [JsonProperty("Reward")]
        public long Reward { get; set; }
    }

    public partial class SearchAndRescueInfo
    {
        public static SearchAndRescueInfo Process(string json) => EventHandler.InvokeSearchAndRescueEvent(JsonConvert.DeserializeObject<SearchAndRescueInfo>(json, EliteAPI.Events.SearchAndRescueConverter.Settings));
    }

    public static class SearchAndRescueSerializer
    {
        public static string ToJson(this SearchAndRescueInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.SearchAndRescueConverter.Settings);
    }

    internal static class SearchAndRescueConverter
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
