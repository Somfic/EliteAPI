namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class EjectCargoInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Type")]
        public string Type { get; internal set; }

        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }

        [JsonProperty("Abandoned")]
        public bool Abandoned { get; internal set; }
    }

    public partial class EjectCargoInfo
    {
        public static EjectCargoInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeEjectCargoEvent(JsonConvert.DeserializeObject<EjectCargoInfo>(json, EliteAPI.Events.EjectCargoConverter.Settings));
    }

    public static class EjectCargoSerializer
    {
        public static string ToJson(this EjectCargoInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.EjectCargoConverter.Settings);
    }

    internal static class EjectCargoConverter
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
