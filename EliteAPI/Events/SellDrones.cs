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
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Type")]
        public string Type { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }

        [JsonProperty("SellPrice")]
        public long SellPrice { get; internal set; }

        [JsonProperty("TotalSale")]
        public long TotalSale { get; internal set; }
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
            MissingMemberHandling = MissingMemberHandling.Ignore, MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
