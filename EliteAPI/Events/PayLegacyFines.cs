namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class PayLegacyFinesInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Amount")]
        public long Amount { get; internal set; }

        [JsonProperty("BrokerPercentage")]
        public double BrokerPercentage { get; internal set; }
    }

    public partial class PayLegacyFinesInfo
    {
        public static PayLegacyFinesInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokePayLegacyFinesEvent(JsonConvert.DeserializeObject<PayLegacyFinesInfo>(json, EliteAPI.Events.PayLegacyFinesConverter.Settings));
    }

    public static class PayLegacyFinesSerializer
    {
        public static string ToJson(this PayLegacyFinesInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.PayLegacyFinesConverter.Settings);
    }

    internal static class PayLegacyFinesConverter
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
