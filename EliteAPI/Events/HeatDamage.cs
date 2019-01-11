namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class HeatDamageInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }
    }

    public partial class HeatDamageInfo
    {
        public static HeatDamageInfo Process(string json, EliteDangerousAPI api) => api.EventHandler.InvokeHeatDamageEvent(JsonConvert.DeserializeObject<HeatDamageInfo>(json, EliteAPI.Events.HeatDamageConverter.Settings));
    }

    public static class HeatDamageSerializer
    {
        public static string ToJson(this HeatDamageInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.HeatDamageConverter.Settings);
    }

    internal static class HeatDamageConverter
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
