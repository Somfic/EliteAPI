namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ReceiveTextInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("From")]
        public string From { get; set; }

        [JsonProperty("From_Localised")]
        public string FromLocalised { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("Message_Localised")]
        public string MessageLocalised { get; set; }

        [JsonProperty("Channel")]
        public string Channel { get; set; }
    }

    public partial class ReceiveTextInfo
    {
        public static ReceiveTextInfo Process(string json, EliteDangerousAPI api) => api.EventHandler.InvokeReceiveTextEvent(JsonConvert.DeserializeObject<ReceiveTextInfo>(json, EliteAPI.Events.ReceiveTextConverter.Settings));
    }

    public static class ReceiveTextSerializer
    {
        public static string ToJson(this ReceiveTextInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.ReceiveTextConverter.Settings);
    }

    internal static class ReceiveTextConverter
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
