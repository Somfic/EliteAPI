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
        public string EngineerName { get; internal set; }
        [JsonProperty("rankStage")]
        public RankStage RankStage { get; internal set; }
        [Range(1, 5)]
        [JsonProperty("rankValue")]
        public short RankValue { get; internal set; }
    }
}
