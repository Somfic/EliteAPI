namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class EngineerApplyInfo : IEvent
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Engineer")]
        public string Engineer { get; internal set; }

        [JsonProperty("Blueprint")]
        public string Blueprint { get; internal set; }

        [JsonProperty("Level")]
        public long Level { get; internal set; }

        [JsonProperty("Override")]
        public string Override { get; internal set; }
    }

    public partial class EngineerApplyInfo
    {
        public static EngineerApplyInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeEngineerApplyEvent(JsonConvert.DeserializeObject<EngineerApplyInfo>(json, EliteAPI.Events.EngineerApplyConverter.Settings));
    }

    

    internal static class EngineerApplyConverter
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
