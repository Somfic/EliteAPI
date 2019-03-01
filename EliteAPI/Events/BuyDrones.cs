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
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Type")]
        public string Type { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }

        [JsonProperty("BuyPrice")]
        public long BuyPrice { get; internal set; }

        [JsonProperty("TotalCost")]
        public long TotalCost { get; internal set; }
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
            MissingMemberHandling = MissingMemberHandling.Ignore, MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
