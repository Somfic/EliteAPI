namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class JetConeDamageInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Module")]
        public string Module { get; set; }

        [JsonProperty("Module_Localised")]
        public string ModuleLocalised { get; set; }
    }

    public partial class JetConeDamageInfo
    {
        public static JetConeDamageInfo Process(string json, EliteDangerousAPI api) => api.EventHandler.InvokeJetConeDamageEvent(JsonConvert.DeserializeObject<JetConeDamageInfo>(json, EliteAPI.Events.JetConeDamageConverter.Settings));
    }

    public static class JetConeDamageSerializer
    {
        public static string ToJson(this JetConeDamageInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.JetConeDamageConverter.Settings);
    }

    internal static class JetConeDamageConverter
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
