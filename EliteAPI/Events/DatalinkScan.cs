namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    public partial class DatalinkScanInfo : IEvent
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Message")]
        public string Message { get; internal set; }
        [JsonProperty("Message_Localised")]
        public string MessageLocalised { get; internal set; }
    }
    public partial class DatalinkScanInfo
    {
        internal static DatalinkScanInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeDatalinkScanEvent(JsonConvert.DeserializeObject<DatalinkScanInfo>(json, EliteAPI.Events.DatalinkScanConverter.Settings));
    }
    
    internal static class DatalinkScanConverter
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
