namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class CrimeVictimInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Offender")]
        public string Offender { get; internal set; }

        [JsonProperty("CrimeType")]
        public string CrimeType { get; internal set; }

        [JsonProperty("Bounty")]
        public long Bounty { get; internal set; }
    }

    public partial class CrimeVictimInfo
    {
        public static CrimeVictimInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCrimeVictimEvent(JsonConvert.DeserializeObject<CrimeVictimInfo>(json, EliteAPI.Events.CrimeVictimConverter.Settings));
    }

    public static class CrimeVictimSerializer
    {
        public static string ToJson(this CrimeVictimInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.CrimeVictimConverter.Settings);
    }

    internal static class CrimeVictimConverter
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
