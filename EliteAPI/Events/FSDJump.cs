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
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        [JsonProperty("StarPos")]
        public List<double> StarPos { get; internal set; }

        [JsonProperty("SystemAllegiance")]
        public string SystemAllegiance { get; internal set; }

        [JsonProperty("SystemEconomy")]
        public string SystemEconomy { get; internal set; }

        [JsonProperty("SystemEconomy_Localised")]
        public string SystemEconomyLocalised { get; internal set; }

        [JsonProperty("SystemSecondEconomy")]
        public string SystemSecondEconomy { get; internal set; }

        [JsonProperty("SystemSecondEconomy_Localised")]
        public string SystemSecondEconomyLocalised { get; internal set; }

        [JsonProperty("SystemGovernment")]
        public string SystemGovernment { get; internal set; }

        [JsonProperty("SystemGovernment_Localised")]
        public string SystemGovernmentLocalised { get; internal set; }

        [JsonProperty("SystemSecurity")]
        public string SystemSecurity { get; internal set; }

        [JsonProperty("SystemSecurity_Localised")]
        public string SystemSecurityLocalised { get; internal set; }

        [JsonProperty("Population")]
        public long Population { get; internal set; }

        [JsonProperty("Powers")]
        public List<string> Powers { get; internal set; }

        [JsonProperty("PowerplayState")]
        public string PowerplayState { get; internal set; }

        [JsonProperty("JumpDist")]
        public double JumpDist { get; internal set; }

        [JsonProperty("FuelUsed")]
        public double FuelUsed { get; internal set; }

        [JsonProperty("FuelLevel")]
        public double FuelLevel { get; internal set; }

        [JsonProperty("Factions")]
        public List<FSDFaction> Factions { get; internal set; }

        [JsonProperty("SystemFaction")]
        public SystemFaction SystemFaction { get; internal set; }

        [JsonProperty("FactionState")]
        public string FactionState { get; internal set; }
    }

    public partial class FSDFaction
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("FactionState")]
        public string FactionState { get; internal set; }

        [JsonProperty("Government")]
        public string Government { get; internal set; }

        [JsonProperty("Influence")]
        public double Influence { get; internal set; }

        [JsonProperty("Allegiance")]
        public string Allegiance { get; internal set; }

        [JsonProperty("Happiness")]
        public string Happiness { get; internal set; }

        [JsonProperty("Happiness_Localised", NullValueHandling = NullValueHandling.Ignore)]
        public string HappinessLocalised { get; internal set; }

        [JsonProperty("MyReputation")]
        public double MyReputation { get; internal set; }

        [JsonProperty("RecoveringStates", NullValueHandling = NullValueHandling.Ignore)]
        public List<IngState> RecoveringStates { get; internal set; }

        [JsonProperty("PendingStates", NullValueHandling = NullValueHandling.Ignore)]
        public List<IngState> PendingStates { get; internal set; }

        [JsonProperty("ActiveStates", NullValueHandling = NullValueHandling.Ignore)]
        public List<ActiveState> ActiveStates { get; internal set; }
    }

    public class FSDActiveState
    {
        [JsonProperty("State")]
        public string State { get; internal set; }
    }

    public class IngState
    {
        [JsonProperty("State")]
        public string State { get; internal set; }

        [JsonProperty("Trend")]
        public long Trend { get; internal set; }
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
            MissingMemberHandling = MissingMemberHandling.Ignore, MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
