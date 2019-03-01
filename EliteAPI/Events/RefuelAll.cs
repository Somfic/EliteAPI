namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class RefuelAllInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        [JsonProperty("Amount")]
        public double Amount { get; internal set; }
    }

    public partial class RefuelAllInfo
    {
        public static RefuelAllInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeRefuelAllEvent(JsonConvert.DeserializeObject<RefuelAllInfo>(json, EliteAPI.Events.RefuelAllConverter.Settings));
    }

    public static class RefuelAllSerializer
    {
        public static string ToJson(this RefuelAllInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.RefuelAllConverter.Settings);
    }

    internal static class RefuelAllConverter
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
