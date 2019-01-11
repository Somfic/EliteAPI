namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class PowerplayVoteInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Power")]
        public string Power { get; set; }

        [JsonProperty("Votes")]
        public long Votes { get; set; }

        [JsonProperty("VoteToConsolidate")]
        public long VoteToConsolidate { get; set; }
    }

    public partial class PowerplayVoteInfo
    {
        public static PowerplayVoteInfo Process(string json) => EventHandler.InvokePowerplayVoteEvent(JsonConvert.DeserializeObject<PowerplayVoteInfo>(json, EliteAPI.Events.PowerplayVoteConverter.Settings));
    }

    public static class PowerplayVoteSerializer
    {
        public static string ToJson(this PowerplayVoteInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.PowerplayVoteConverter.Settings);
    }

    internal static class PowerplayVoteConverter
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
