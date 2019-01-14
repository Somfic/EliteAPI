namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class EngineerApplyInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Engineer")]
        public string Engineer { get; set; }

        [JsonProperty("Blueprint")]
        public string Blueprint { get; set; }

        [JsonProperty("Level")]
        public long Level { get; set; }

        [JsonProperty("Override")]
        public string Override { get; set; }
    }

    public partial class EngineerApplyInfo
    {
        public static EngineerApplyInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeEngineerApplyEvent(JsonConvert.DeserializeObject<EngineerApplyInfo>(json, EliteAPI.Events.EngineerApplyConverter.Settings));
    }

    public static class EngineerApplySerializer
    {
        public static string ToJson(this EngineerApplyInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.EngineerApplyConverter.Settings);
    }

    internal static class EngineerApplyConverter
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
