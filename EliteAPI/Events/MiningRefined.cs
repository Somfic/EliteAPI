namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class MiningRefinedInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Type")]
        public string Type { get; internal set; }

        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; internal set; }
    }

    public partial class MiningRefinedInfo
    {
        public static MiningRefinedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMiningRefinedEvent(JsonConvert.DeserializeObject<MiningRefinedInfo>(json, EliteAPI.Events.MiningRefinedConverter.Settings));
    }

    public static class MiningRefinedSerializer
    {
        public static string ToJson(this MiningRefinedInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.MiningRefinedConverter.Settings);
    }

    internal static class MiningRefinedConverter
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
