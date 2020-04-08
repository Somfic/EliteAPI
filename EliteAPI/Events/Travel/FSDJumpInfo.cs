using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events.Travel
{
    public class FSDJumpInfo : EventBase
    {
        internal FSDJumpInfo() { }

        /// <summary>
        /// The name of the destination star system.
        /// </summary>
        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        /// <summary>
        /// The address of the destination star system.aW
        /// </summary>
        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        /// <summary>
        /// The position of the destination star system in light years.
        /// </summary>
        [JsonProperty("StarPos")]
        public List<float> StarPos { get; internal set; }

        /// <summary>
        /// The name of the destination star.
        /// </summary>
        [JsonProperty("Body")]
        public string Body { get; internal set; }

        /// <summary>
        /// The total distance jumped.
        /// </summary>
        [JsonProperty("JumpDist")]
        public float JumpDist { get; internal set; }

        /// <summary>
        /// The amount of fuel used.
        /// </summary>
        [JsonProperty("FuelUsed")]
        public float FuelUsed { get; internal set; }

        /// <summary>
        /// The total amount of remaining fuel in the ship.
        /// </summary>
        [JsonProperty("FuelLevel")]
        public float FuelLevel { get; internal set; }

        /// <summary>
        /// Whether a FSD boost was used.
        /// </summary>
        [JsonProperty("BoostUsed")]
        public bool BoostUsed { get; internal set; }

        /// <summary>
        /// The faction controlling the destination system.
        /// </summary>
        /// <see cref="FsdJumpSystemFaction"/>
        [JsonProperty("SystemFaction")]
        public FSDJumpSystemFaction FsdJumpSystemFaction { get; internal set; }

        /// <summary>
        /// The allegiance of the system.
        /// </summary>
        [JsonProperty("SystemAllegiance")]
        public string SystemAllegiance { get; internal set; } //todo: turn this into an enum

        /// <summary>
        /// The system's main economy.
        /// </summary>
        [JsonProperty("SystemEconomy")]
        public string SystemEconomy { get; internal set; } //todo: turn this into an enum

        /// <summary>
        /// The system's main economy localised.
        /// </summary>
        [JsonProperty("SystemEconomy_Localised")]
        public string SystemEconomyLocalised { get; internal set; }

        /// <summary>
        /// The system's secondary economy.
        /// </summary>
        [JsonProperty("SystemSecondEconomy")]
        public string SystemSecondEconomy { get; internal set; } //todo: turn this into an enum

        /// <summary>
        /// The system's secondary economy localised.
        /// </summary>
        [JsonProperty("SystemSecondEconomy_Localised")]
        public string SystemSecondEconomyLocalised { get; internal set; }
        
        /// <summary>
        /// The system's government.
        /// </summary>
        [JsonProperty("SystemGovernment")]
        public string SystemGovernment { get; internal set; }

        /// <summary>
        /// The system's government localised.
        /// </summary>
        [JsonProperty("SystemGovernment_Localised")]
        public string SystemGovernmentLocalised { get; internal set; }

        [JsonProperty("SystemSecurity")]
        public string SystemSecurity { get; internal set; }

        [JsonProperty("SystemSecurity_Localised")]
        public string SystemSecurityLocalised { get; internal set; }

        [JsonProperty("Population")]
        public long Population { get; internal set; }

        [JsonProperty("Wanted")]
        public bool Wanted { get; internal set; }

        [JsonProperty("Factions")]
        public List<FSDJumpFaction> Factions { get; internal set; }

        [JsonProperty("Powers")]
        public List<string> Powers { get; internal set; }


        [JsonProperty("PowerplayState")]
        public string PowerplayState { get; internal set; }


        [JsonProperty("FactionState")]
        public string FactionState { get; internal set; }

        internal static FSDJumpInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeFSDJumpEvent(JsonConvert.DeserializeObject<FSDJumpInfo>(json, JsonSettings.Settings));
        }
    }
}