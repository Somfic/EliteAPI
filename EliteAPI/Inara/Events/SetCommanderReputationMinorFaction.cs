using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EliteAPI.Inara.Events
{
    public class SetCommanderReputationMinorFaction : IInaraEventData
    {
        public SetCommanderReputationMinorFaction(string factionName, decimal factionReputation)
        {
            FactionName = factionName;
            FactionReputation = factionReputation;
        }

        [JsonProperty("minorFactionName")]
        public string FactionName { get; internal set; }

        [Range(-1, 1)]
        [JsonProperty("minorFactionReputation")]
        public decimal FactionReputation { get; internal set; }
    }
}
