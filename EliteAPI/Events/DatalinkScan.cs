namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class DatalinkScanInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("Message_Localised")]
        public string MessageLocalised { get; set; }
    }

    public partial class DatalinkScanInfo
    {
        public static DatalinkScanInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeDatalinkScanEvent(JsonConvert.DeserializeObject<DatalinkScanInfo>(json, EliteAPI.Events.DatalinkScanConverter.Settings));
    }

    public static class DatalinkScanSerializer
    {
        public static string ToJson(this DatalinkScanInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.DatalinkScanConverter.Settings);
    }

    internal static class DatalinkScanConverter
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
