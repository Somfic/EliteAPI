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
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("From")]
        public string From { get; internal set; }

        [JsonProperty("From_Localised")]
        public string FromLocalised { get; internal set; }

        [JsonProperty("Message")]
        public string Message { get; internal set; }

        [JsonProperty("Message_Localised")]
        public string MessageLocalised { get; internal set; }

        [JsonProperty("Channel")]
        public string Channel { get; internal set; }
    }

    public partial class ReceiveTextInfo
    {
        public static ReceiveTextInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeReceiveTextEvent(JsonConvert.DeserializeObject<ReceiveTextInfo>(json, EliteAPI.Events.ReceiveTextConverter.Settings));
    }

    public static class ReceiveTextSerializer
    {
        public static string ToJson(this ReceiveTextInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.ReceiveTextConverter.Settings);
    }

    internal static class ReceiveTextConverter
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
