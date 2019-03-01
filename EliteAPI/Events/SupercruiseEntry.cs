namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class SupercruiseEntryInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }
    }

    public partial class SupercruiseEntryInfo
    {
        public static SupercruiseEntryInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeSupercruiseEntryEvent(JsonConvert.DeserializeObject<SupercruiseEntryInfo>(json, EliteAPI.Events.SupercruiseEntryConverter.Settings));
    }

    public static class SupercruiseEntrySerializer
    {
        public static string ToJson(this SupercruiseEntryInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.SupercruiseEntryConverter.Settings);
    }

    internal static class SupercruiseEntryConverter
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
