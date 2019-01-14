using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EliteAPI.Inara.Events
{
    public class SetCommanderRankEngineer : IInaraEventData
    {
        public SetCommanderRankEngineer(string engineerName)
        {
            EngineerName = engineerName;
        }

        [JsonProperty("engineerName")]
        public string EngineerName { get; set; }

        [JsonProperty("rankStage")]
        public RankStage RankStage { get; set; }

        [Range(1, 5)]
        [JsonProperty("rankValue")]
        public long RankValue { get; set; }
    }

    public enum RankStage
    {
        Invited,
        Acquainted,
        Unlocked,
        Barred
    }
}
