namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class FactionKillBondInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Reward")]
        public long Reward { get; set; }

        [JsonProperty("AwardingFaction")]
        public string AwardingFaction { get; set; }

        [JsonProperty("AwardingFaction_Localised")]
        public string AwardingFactionLocalised { get; set; }

        [JsonProperty("VictimFaction")]
        public string VictimFaction { get; set; }

        [JsonProperty("VictimFaction_Localised")]
        public string VictimFactionLocalised { get; set; }
    }

    public partial class FactionKillBondInfo
    {
        public static FactionKillBondInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeFactionKillBondEvent(JsonConvert.DeserializeObject<FactionKillBondInfo>(json, EliteAPI.Events.FactionKillBondConverter.Settings));
    }

    public static class FactionKillBondSerializer
    {
        public static string ToJson(this FactionKillBondInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.FactionKillBondConverter.Settings);
    }

    internal static class FactionKillBondConverter
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
