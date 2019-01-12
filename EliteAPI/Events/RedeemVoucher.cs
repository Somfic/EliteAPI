namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class RedeemVoucherInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Amount")]
        public long Amount { get; set; }

        [JsonProperty("Factions")]
        public List<Faction> Factions { get; set; }
    }

    public partial class Faction
    {
        [JsonProperty("Faction")]
        public string FactionFaction { get; set; }

        [JsonProperty("Amount")]
        public long Amount { get; set; }
    }

    public partial class RedeemVoucherInfo
    {
        public static RedeemVoucherInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeRedeemVoucherEvent(JsonConvert.DeserializeObject<RedeemVoucherInfo>(json, EliteAPI.Events.RedeemVoucherConverter.Settings));
    }

    public static class RedeemVoucherSerializer
    {
        public static string ToJson(this RedeemVoucherInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.RedeemVoucherConverter.Settings);
    }

    internal static class RedeemVoucherConverter
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
