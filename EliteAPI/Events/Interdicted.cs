namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    public partial class InterdictedInfo : IEvent
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Submitted")]
        public bool Submitted { get; internal set; }
        [JsonProperty("Interdictor")]
        public string Interdictor { get; internal set; }
        [JsonProperty("Interdictor_Localised")]
        public string InterdictorLocalised { get; internal set; }
        [JsonProperty("IsPlayer")]
        public bool IsPlayer { get; internal set; }
        [JsonProperty("Faction")]
        public string Faction { get; internal set; }
    }
    public partial class InterdictedInfo
    {
        internal static InterdictedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeInterdictedEvent(JsonConvert.DeserializeObject<InterdictedInfo>(json, EliteAPI.Events.InterdictedConverter.Settings));
    }
    
    internal static class InterdictedConverter
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
