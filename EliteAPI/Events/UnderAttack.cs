namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class UnderAttackInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Target")]
        public string Target { get; set; }
    }

    public partial class UnderAttackInfo
    {
        public static UnderAttackInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeUnderAttackEvent(JsonConvert.DeserializeObject<UnderAttackInfo>(json, EliteAPI.Events.UnderAttackConverter.Settings));
    }

    public static class UnderAttackSerializer
    {
        public static string ToJson(this UnderAttackInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.UnderAttackConverter.Settings);
    }

    internal static class UnderAttackConverter
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
