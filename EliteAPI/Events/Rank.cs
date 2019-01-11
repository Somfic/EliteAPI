namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class RankInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Combat")]
        public long Combat { get; set; }

        [JsonProperty("Trade")]
        public long Trade { get; set; }

        [JsonProperty("Explore")]
        public long Explore { get; set; }

        [JsonProperty("Empire")]
        public long Empire { get; set; }

        [JsonProperty("Federation")]
        public long Federation { get; set; }

        [JsonProperty("CQC")]
        public long Cqc { get; set; }
    }

    public partial class RankInfo
    {
        public static RankInfo Process(string json, EliteDangerousAPI api) => api.EventHandler.InvokeRankEvent(JsonConvert.DeserializeObject<RankInfo>(json, EliteAPI.Events.RankConverter.Settings));
    }

    public static class RankSerializer
    {
        public static string ToJson(this RankInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.RankConverter.Settings);
    }

    internal static class RankConverter
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
