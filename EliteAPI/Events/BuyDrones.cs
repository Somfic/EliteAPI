namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class BuyDronesInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Count")]
        public long Count { get; set; }

        [JsonProperty("BuyPrice")]
        public long BuyPrice { get; set; }

        [JsonProperty("TotalCost")]
        public long TotalCost { get; set; }
    }

    public partial class BuyDronesInfo
    {
        public static BuyDronesInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeBuyDronesEvent(JsonConvert.DeserializeObject<BuyDronesInfo>(json, EliteAPI.Events.BuyDronesConverter.Settings));
    }

    public static class BuyDronesSerializer
    {
        public static string ToJson(this BuyDronesInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.BuyDronesConverter.Settings);
    }

    internal static class BuyDronesConverter
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
