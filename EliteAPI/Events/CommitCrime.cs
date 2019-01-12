namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class CommitCrimeInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("CrimeType")]
        public string CrimeType { get; set; }

        [JsonProperty("Faction")]
        public string Faction { get; set; }

        [JsonProperty("Victim")]
        public string Victim { get; set; }

        [JsonProperty("Victim_Localised")]
        public string VictimLocalised { get; set; }

        [JsonProperty("Bounty")]
        public long Bounty { get; set; }
    }

    public partial class CommitCrimeInfo
    {
        public static CommitCrimeInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCommitCrimeEvent(JsonConvert.DeserializeObject<CommitCrimeInfo>(json, EliteAPI.Events.CommitCrimeConverter.Settings));
    }

    public static class CommitCrimeSerializer
    {
        public static string ToJson(this CommitCrimeInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.CommitCrimeConverter.Settings);
    }

    internal static class CommitCrimeConverter
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
