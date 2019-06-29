namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class FactionKillBondInfo : IEvent
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Reward")]
        public long Reward { get; internal set; }

        [JsonProperty("AwardingFaction")]
        public string AwardingFaction { get; internal set; }

        [JsonProperty("AwardingFaction_Localised")]
        public string AwardingFactionLocalised { get; internal set; }

        [JsonProperty("VictimFaction")]
        public string VictimFaction { get; internal set; }

        [JsonProperty("VictimFaction_Localised")]
        public string VictimFactionLocalised { get; internal set; }
    }

    public partial class FactionKillBondInfo
    {
        public static FactionKillBondInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeFactionKillBondEvent(JsonConvert.DeserializeObject<FactionKillBondInfo>(json, EliteAPI.Events.FactionKillBondConverter.Settings));
    }

    

    internal static class FactionKillBondConverter
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
