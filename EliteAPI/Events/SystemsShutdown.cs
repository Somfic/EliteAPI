namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    public partial class SystemsShutdownInfo : IEvent
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
    }
    public partial class SystemsShutdownInfo
    {
        internal static SystemsShutdownInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeSystemsShutdownEvent(JsonConvert.DeserializeObject<SystemsShutdownInfo>(json, EliteAPI.Events.SystemsShutdownConverter.Settings));
    }
    
    internal static class SystemsShutdownConverter
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
