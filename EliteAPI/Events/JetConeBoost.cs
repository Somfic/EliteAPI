namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class JetConeBoostInfo : IEvent
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("BoostValue")]
        public double BoostValue { get; internal set; }
    }

    public partial class JetConeBoostInfo
    {
        public static JetConeBoostInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeJetConeBoostEvent(JsonConvert.DeserializeObject<JetConeBoostInfo>(json, EliteAPI.Events.JetConeBoostConverter.Settings));
    }

    

    internal static class JetConeBoostConverter
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
