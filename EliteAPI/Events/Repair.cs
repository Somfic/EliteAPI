namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class RepairInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Item")]
        public string Item { get; set; }

        [JsonProperty("Cost")]
        public long Cost { get; set; }
    }

    public partial class RepairInfo
    {
        public static RepairInfo Process(string json, EliteDangerousAPI api) => api.EventHandler.InvokeRepairEvent(JsonConvert.DeserializeObject<RepairInfo>(json, EliteAPI.Events.RepairConverter.Settings));
    }

    public static class RepairSerializer
    {
        public static string ToJson(this RepairInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.RepairConverter.Settings);
    }

    internal static class RepairConverter
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
