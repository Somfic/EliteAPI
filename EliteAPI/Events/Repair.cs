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
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Item")]
        public string Item { get; internal set; }

        [JsonProperty("Cost")]
        public long Cost { get; internal set; }
    }

    public partial class RepairInfo
    {
        public static RepairInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeRepairEvent(JsonConvert.DeserializeObject<RepairInfo>(json, EliteAPI.Events.RepairConverter.Settings));
    }

    public static class RepairSerializer
    {
        public static string ToJson(this RepairInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.RepairConverter.Settings);
    }

    internal static class RepairConverter
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
