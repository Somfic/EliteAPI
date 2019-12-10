namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    public partial class CockpitBreachedInfo : IEvent
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
    }
    public partial class CockpitBreachedInfo
    {
        internal static CockpitBreachedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCockpitBreachedEvent(JsonConvert.DeserializeObject<CockpitBreachedInfo>(json, EliteAPI.Events.CockpitBreachedConverter.Settings));
    }
    
    internal static class CockpitBreachedConverter
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
