namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    public partial class JetConeDamageInfo : IEvent
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Module")]
        public string Module { get; internal set; }
        [JsonProperty("Module_Localised")]
        public string ModuleLocalised { get; internal set; }
    }
    public partial class JetConeDamageInfo
    {
        internal static JetConeDamageInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeJetConeDamageEvent(JsonConvert.DeserializeObject<JetConeDamageInfo>(json, EliteAPI.Events.JetConeDamageConverter.Settings));
    }
    
    internal static class JetConeDamageConverter
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
