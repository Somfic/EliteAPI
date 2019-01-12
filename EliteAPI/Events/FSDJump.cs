namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class FSDJumpInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; set; }

        [JsonProperty("StarPos")]
        public List<double> StarPos { get; set; }

        [JsonProperty("SystemAllegiance")]
        public string SystemAllegiance { get; set; }

        [JsonProperty("SystemEconomy")]
        public string SystemEconomy { get; set; }

        [JsonProperty("SystemEconomy_Localised")]
        public string SystemEconomyLocalised { get; set; }

        [JsonProperty("SystemSecondEconomy")]
        public string SystemSecondEconomy { get; set; }

        [JsonProperty("SystemSecondEconomy_Localised")]
        public string SystemSecondEconomyLocalised { get; set; }

        [JsonProperty("SystemGovernment")]
        public string SystemGovernment { get; set; }

        [JsonProperty("SystemGovernment_Localised")]
        public string SystemGovernmentLocalised { get; set; }

        [JsonProperty("SystemSecurity")]
        public string SystemSecurity { get; set; }

        [JsonProperty("SystemSecurity_Localised")]
        public string SystemSecurityLocalised { get; set; }

        [JsonProperty("Population")]
        public long Population { get; set; }

        [JsonProperty("Powers")]
        public List<string> Powers { get; set; }

        [JsonProperty("PowerplayState")]
        public string PowerplayState { get; set; }

        [JsonProperty("JumpDist")]
        public double JumpDist { get; set; }

        [JsonProperty("FuelUsed")]
        public double FuelUsed { get; set; }

        [JsonProperty("FuelLevel")]
        public double FuelLevel { get; set; }

        [JsonProperty("Factions")]
        public List<Faction> Factions { get; set; }

        [JsonProperty("SystemFaction")]
        public string SystemFaction { get; set; }

        [JsonProperty("FactionState")]
        public string FactionState { get; set; }
    }

    public partial class Faction
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("FactionState")]
        public string FactionState { get; set; }

        [JsonProperty("Government")]
        public string Government { get; set; }

        [JsonProperty("Influence")]
        public double Influence { get; set; }

        [JsonProperty("Allegiance")]
        public string Allegiance { get; set; }

        [JsonProperty("Happiness")]
        public string Happiness { get; set; }

        [JsonProperty("Happiness_Localised", NullValueHandling = NullValueHandling.Ignore)]
        public string HappinessLocalised { get; set; }

        [JsonProperty("MyReputation")]
        public double MyReputation { get; set; }

        [JsonProperty("RecoveringStates", NullValueHandling = NullValueHandling.Ignore)]
        public List<IngState> RecoveringStates { get; set; }

        [JsonProperty("PendingStates", NullValueHandling = NullValueHandling.Ignore)]
        public List<IngState> PendingStates { get; set; }

        [JsonProperty("ActiveStates", NullValueHandling = NullValueHandling.Ignore)]
        public List<ActiveState> ActiveStates { get; set; }
    }

    public partial class ActiveState
    {
        [JsonProperty("State")]
        public string State { get; set; }
    }

    public partial class IngState
    {
        [JsonProperty("State")]
        public string State { get; set; }

        [JsonProperty("Trend")]
        public long Trend { get; set; }
    }

    public partial class FSDJumpInfo
    {
        public static FSDJumpInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeFSDJumpEvent(JsonConvert.DeserializeObject<FSDJumpInfo>(json, EliteAPI.Events.FSDJumpConverter.Settings));
    }

    public static class FSDJumpSerializer
    {
        public static string ToJson(this FSDJumpInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.FSDJumpConverter.Settings);
    }

    internal static class FSDJumpConverter
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
