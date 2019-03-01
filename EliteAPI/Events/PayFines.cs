namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class PayFinesInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Amount")]
        public long Amount { get; internal set; }

        [JsonProperty("AllFines")]
        public bool AllFines { get; internal set; }

        [JsonProperty("Faction")]
        public string Faction { get; internal set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }
    }

    public partial class PayFinesInfo
    {
        public static PayFinesInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokePayFinesEvent(JsonConvert.DeserializeObject<PayFinesInfo>(json, EliteAPI.Events.PayFinesConverter.Settings));
    }

    public static class PayFinesSerializer
    {
        public static string ToJson(this PayFinesInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.PayFinesConverter.Settings);
    }

    internal static class PayFinesConverter
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
