namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    public partial class SearchAndRescueInfo : IEvent
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Name")]
        public string Name { get; internal set; }
        [JsonProperty("Count")]
        public long Count { get; internal set; }
        [JsonProperty("Reward")]
        public long Reward { get; internal set; }
    }
    public partial class SearchAndRescueInfo
    {
        internal static SearchAndRescueInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeSearchAndRescueEvent(JsonConvert.DeserializeObject<SearchAndRescueInfo>(json, EliteAPI.Events.SearchAndRescueConverter.Settings));
    }
    
    internal static class SearchAndRescueConverter
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
