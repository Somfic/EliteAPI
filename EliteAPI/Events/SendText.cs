namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class SendTextInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("To")]
        public string To { get; internal set; }

        [JsonProperty("To_Localised")]
        public string ToLocalised { get; internal set; }

        [JsonProperty("Message")]
        public string Message { get; internal set; }
    }

    public partial class SendTextInfo
    {
        public static SendTextInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeSendTextEvent(JsonConvert.DeserializeObject<SendTextInfo>(json, EliteAPI.Events.SendTextConverter.Settings));
    }

    public static class SendTextSerializer
    {
        public static string ToJson(this SendTextInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.SendTextConverter.Settings);
    }

    internal static class SendTextConverter
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
