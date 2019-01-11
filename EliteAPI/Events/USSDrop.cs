namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class USSDropInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("USSType")]
        public string UssType { get; set; }

        [JsonProperty("USSType_Localised")]
        public string UssTypeLocalised { get; set; }

        [JsonProperty("USSThreat")]
        public long UssThreat { get; set; }
    }

    public partial class USSDropInfo
    {
        public static USSDropInfo Process(string json) => EventHandler.InvokeUSSDropEvent(JsonConvert.DeserializeObject<USSDropInfo>(json, EliteAPI.Events.USSDropConverter.Settings));
    }

    public static class USSDropSerializer
    {
        public static string ToJson(this USSDropInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.USSDropConverter.Settings);
    }

    internal static class USSDropConverter
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
