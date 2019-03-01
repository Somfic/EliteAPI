namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ApproachSettlementInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; internal set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("Latitude")]
        public double Latitude { get; internal set; }

        [JsonProperty("Longitude")]
        public double Longitude { get; internal set; }
    }

    public partial class ApproachSettlementInfo
    {
        public static ApproachSettlementInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeApproachSettlementEvent(JsonConvert.DeserializeObject<ApproachSettlementInfo>(json, EliteAPI.Events.ApproachSettlementConverter.Settings));
    }

    public static class ApproachSettlementSerializer
    {
        public static string ToJson(this ApproachSettlementInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.ApproachSettlementConverter.Settings);
    }

    internal static class ApproachSettlementConverter
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
