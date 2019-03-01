namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class BuyAmmoInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Cost")]
        public long Cost { get; internal set; }
    }

    public partial class BuyAmmoInfo
    {
        public static BuyAmmoInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeBuyAmmoEvent(JsonConvert.DeserializeObject<BuyAmmoInfo>(json, EliteAPI.Events.BuyAmmoConverter.Settings));
    }

    public static class BuyAmmoSerializer
    {
        public static string ToJson(this BuyAmmoInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.BuyAmmoConverter.Settings);
    }

    internal static class BuyAmmoConverter
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
