namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class JetConeBoostInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("BoostValue")]
        public double BoostValue { get; set; }
    }

    public partial class JetConeBoostInfo
    {
        public static JetConeBoostInfo Process(string json) => EventHandler.InvokeJetConeBoostEvent(JsonConvert.DeserializeObject<JetConeBoostInfo>(json, EliteAPI.Events.JetConeBoostConverter.Settings));
    }

    public static class JetConeBoostSerializer
    {
        public static string ToJson(this JetConeBoostInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.JetConeBoostConverter.Settings);
    }

    internal static class JetConeBoostConverter
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
