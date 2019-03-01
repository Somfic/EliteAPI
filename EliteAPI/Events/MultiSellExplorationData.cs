namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class MultiSellExplorationDataInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Discovered")]
        public List<Discovered> Discovered { get; internal set; }

        [JsonProperty("BaseValue")]
        public long BaseValue { get; internal set; }

        [JsonProperty("Bonus")]
        public long Bonus { get; internal set; }

        [JsonProperty("TotalEarnings")]
        public long TotalEarnings { get; internal set; }
    }

    public partial class Discovered
    {
        [JsonProperty("SystemName")]
        public string SystemName { get; internal set; }

        [JsonProperty("NumBodies")]
        public long NumBodies { get; internal set; }
    }

    public partial class MultiSellExplorationDataInfo
    {
        public static MultiSellExplorationDataInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMultiSellExplorationDataEvent(JsonConvert.DeserializeObject<MultiSellExplorationDataInfo>(json, EliteAPI.Events.MultiSellExplorationDataConverter.Settings));
    }

    public static class MultiSellExplorationDataSerializer
    {
        public static string ToJson(this MultiSellExplorationDataInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.MultiSellExplorationDataConverter.Settings);
    }

    internal static class MultiSellExplorationDataConverter
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
