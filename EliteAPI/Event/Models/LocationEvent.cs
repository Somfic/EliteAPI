using System.Collections.Generic;
using EliteAPI.Event.Models.Abstractions;
using EliteAPI.Event.Models.Travel;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class LocationEvent : EventBase
    {
        internal LocationEvent() { }

        public static LocationEvent FromJson(string json) => JsonConvert.DeserializeObject<LocationEvent>(json);


        [JsonProperty("Docked")]
        public bool Docked { get; internal set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        [JsonProperty("StarPos")]
        public List<float> StarPos { get; internal set; }

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

        [JsonProperty("Body")]
        public string Body { get; internal set; }

        [JsonProperty("BodyID")]
        public long BodyId { get; internal set; }

        [JsonProperty("BodyType")]
        public string BodyType { get; internal set; }

        [JsonProperty("Factions")]
        public List<Faction> Factions { get; internal set; }

        [JsonProperty("SystemFaction")]
        public FSDJumpSystemFaction FsdJumpSystemFaction { get; internal set; }

        
    }
}