namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class DisbandedSquadronInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("SquadronName")]
        public string SquadronName { get; set; }
    }

    public partial class DisbandedSquadronInfo
    {
        public static DisbandedSquadronInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeDisbandedSquadronEvent(JsonConvert.DeserializeObject<DisbandedSquadronInfo>(json, EliteAPI.Events.DisbandedSquadronConverter.Settings));
    }

    public static class DisbandedSquadronSerializer
    {
        public static string ToJson(this DisbandedSquadronInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.DisbandedSquadronConverter.Settings);
    }

    internal static class DisbandedSquadronConverter
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
