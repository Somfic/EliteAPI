namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class SquadronCreatedInfo : IEvent
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("SquadronName")]
        public string SquadronName { get; internal set; }
    }

    public partial class SquadronCreatedInfo
    {
        public static SquadronCreatedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeSquadronCreatedEvent(JsonConvert.DeserializeObject<SquadronCreatedInfo>(json, EliteAPI.Events.SquadronCreatedConverter.Settings));
    }

    

    internal static class SquadronCreatedConverter
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
