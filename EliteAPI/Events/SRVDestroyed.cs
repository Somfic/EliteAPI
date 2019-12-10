namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    public partial class SRVDestroyedInfo : IEvent
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
    }
    public partial class SRVDestroyedInfo
    {
        internal static SRVDestroyedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeSRVDestroyedEvent(JsonConvert.DeserializeObject<SRVDestroyedInfo>(json, EliteAPI.Events.SRVDestroyedConverter.Settings));
    }
    
    internal static class SRVDestroyedConverter
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
