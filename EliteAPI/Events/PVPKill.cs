namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class PVPKillInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Victim")]
        public string Victim { get; set; }

        [JsonProperty("CombatRank")]
        public long CombatRank { get; set; }
    }

    public partial class PVPKillInfo
    {
        public static PVPKillInfo Process(string json, EliteDangerousAPI api) => api.EventHandler.InvokePVPKillEvent(JsonConvert.DeserializeObject<PVPKillInfo>(json, EliteAPI.Events.PVPKillConverter.Settings));
    }

    public static class PVPKillSerializer
    {
        public static string ToJson(this PVPKillInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.PVPKillConverter.Settings);
    }

    internal static class PVPKillConverter
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
