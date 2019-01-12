namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class SellDronesInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Count")]
        public long Count { get; set; }

        [JsonProperty("SellPrice")]
        public long SellPrice { get; set; }

        [JsonProperty("TotalSale")]
        public long TotalSale { get; set; }
    }

    public partial class SellDronesInfo
    {
        public static SellDronesInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeSellDronesEvent(JsonConvert.DeserializeObject<SellDronesInfo>(json, EliteAPI.Events.SellDronesConverter.Settings));
    }

    public static class SellDronesSerializer
    {
        public static string ToJson(this SellDronesInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.SellDronesConverter.Settings);
    }

    internal static class SellDronesConverter
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
