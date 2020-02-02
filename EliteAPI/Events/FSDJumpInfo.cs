using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class FSDJumpInfo : EventBase
    {
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

        internal static FSDJumpInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeFSDJumpEvent(JsonConvert.DeserializeObject<FSDJumpInfo>(json, JsonSettings.Settings));
        }
    }
}