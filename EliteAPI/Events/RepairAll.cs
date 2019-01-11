namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class RepairAllInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Cost")]
        public long Cost { get; set; }
    }

    public partial class RepairAllInfo
    {
        public static RepairAllInfo Process(string json, EliteDangerousAPI api) => api.EventHandler.InvokeRepairAllEvent(JsonConvert.DeserializeObject<RepairAllInfo>(json, EliteAPI.Events.RepairAllConverter.Settings));
    }

    public static class RepairAllSerializer
    {
        public static string ToJson(this RepairAllInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.RepairAllConverter.Settings);
    }

    internal static class RepairAllConverter
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
