using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace EliteAPI.Inara.Events
{
    public class SetCommanderReputationMajorFaction : IInaraEventData
    {
        public SetCommanderReputationMajorFaction(string factionName, decimal factionReputation)
        {
            FactionName = factionName;
            FactionReputation = factionReputation;
        }
        [JsonProperty("majorFactionName")]
        public string FactionName { get; internal set; }
        [Range(-1, 1)]
        [JsonProperty("majorFactionReputation")]
        public decimal FactionReputation { get; internal set; }
    }
}
