namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class SellExplorationDataInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Systems")]
        public List<string> Systems { get; internal set; }

        [JsonProperty("Discovered")]
        public List<string> Discovered { get; internal set; }

        [JsonProperty("BaseValue")]
        public long BaseValue { get; internal set; }

        [JsonProperty("Bonus")]
        public long Bonus { get; internal set; }

        [JsonProperty("TotalEarnings")]
        public long TotalEarnings { get; internal set; }
    }

    public partial class SellExplorationDataInfo
    {
        public static SellExplorationDataInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeSellExplorationDataEvent(JsonConvert.DeserializeObject<SellExplorationDataInfo>(json, EliteAPI.Events.SellExplorationDataConverter.Settings));
    }

    public static class SellExplorationDataSerializer
    {
        public static string ToJson(this SellExplorationDataInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.SellExplorationDataConverter.Settings);
    }

    internal static class SellExplorationDataConverter
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
