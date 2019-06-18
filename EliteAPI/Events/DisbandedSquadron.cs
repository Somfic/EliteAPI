namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class DisbandedSquadronInfo : IEvent
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("SquadronName")]
        public string SquadronName { get; internal set; }
    }

    public partial class DisbandedSquadronInfo
    {
        public static DisbandedSquadronInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeDisbandedSquadronEvent(JsonConvert.DeserializeObject<DisbandedSquadronInfo>(json, EliteAPI.Events.DisbandedSquadronConverter.Settings));
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
