namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class PVPKillInfo : IEvent
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Victim")]
        public string Victim { get; internal set; }

        [JsonProperty("CombatRank")]
        public long CombatRank { get; internal set; }
    }

    public partial class PVPKillInfo
    {
        public static PVPKillInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokePVPKillEvent(JsonConvert.DeserializeObject<PVPKillInfo>(json, EliteAPI.Events.PVPKillConverter.Settings));
    }

    

    internal static class PVPKillConverter
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
