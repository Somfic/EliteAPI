namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    public partial class ShieldStateInfo : IEvent
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("ShieldsUp")]
        public bool ShieldsUp { get; internal set; }
    }
    public partial class ShieldStateInfo
    {
        internal static ShieldStateInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeShieldStateEvent(JsonConvert.DeserializeObject<ShieldStateInfo>(json, EliteAPI.Events.ShieldStateConverter.Settings));
    }
    
    internal static class ShieldStateConverter
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
