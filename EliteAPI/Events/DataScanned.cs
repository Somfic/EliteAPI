namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class DataScannedInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; set; }
    }

    public partial class DataScannedInfo
    {
        public static DataScannedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeDataScannedEvent(JsonConvert.DeserializeObject<DataScannedInfo>(json, EliteAPI.Events.DataScannedConverter.Settings));
    }

    public static class DataScannedSerializer
    {
        public static string ToJson(this DataScannedInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.DataScannedConverter.Settings);
    }

    internal static class DataScannedConverter
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
