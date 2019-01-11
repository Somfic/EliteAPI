namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class RebootRepairInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Modules")]
        public List<string> Modules { get; set; }
    }

    public partial class RebootRepairInfo
    {
        public static RebootRepairInfo Process(string json) => EventHandler.InvokeRebootRepairEvent(JsonConvert.DeserializeObject<RebootRepairInfo>(json, EliteAPI.Events.RebootRepairConverter.Settings));
    }

    public static class RebootRepairSerializer
    {
        public static string ToJson(this RebootRepairInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.RebootRepairConverter.Settings);
    }

    internal static class RebootRepairConverter
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
