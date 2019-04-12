namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class PowerplayVoteInfo : IEvent
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Power")]
        public string Power { get; internal set; }

        [JsonProperty("Votes")]
        public long Votes { get; internal set; }

        [JsonProperty("VoteToConsolidate")]
        public long VoteToConsolidate { get; internal set; }
    }

    public partial class PowerplayVoteInfo
    {
        public static PowerplayVoteInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokePowerplayVoteEvent(JsonConvert.DeserializeObject<PowerplayVoteInfo>(json, EliteAPI.Events.PowerplayVoteConverter.Settings));
    }

    public static class PowerplayVoteSerializer
    {
        public static string ToJson(this PowerplayVoteInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.PowerplayVoteConverter.Settings);
    }

    internal static class PowerplayVoteConverter
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
