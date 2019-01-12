namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ShieldStateInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("ShieldsUp")]
        public bool ShieldsUp { get; set; }
    }

    public partial class ShieldStateInfo
    {
        public static ShieldStateInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeShieldStateEvent(JsonConvert.DeserializeObject<ShieldStateInfo>(json, EliteAPI.Events.ShieldStateConverter.Settings));
    }

    public static class ShieldStateSerializer
    {
        public static string ToJson(this ShieldStateInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.ShieldStateConverter.Settings);
    }

    internal static class ShieldStateConverter
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
