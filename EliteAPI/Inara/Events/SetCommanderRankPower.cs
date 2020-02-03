using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
namespace EliteAPI.Inara.Events
{
    public class SetCommanderRankPower : IInaraEventData
    {
        public SetCommanderRankPower(string powerName, short rankValue)
        {
            PowerName = powerName;
            RankValue = rankValue;
        }
        [JsonProperty("powerName")]
        public string PowerName { get; internal set; }
        [Range(0, 5)]
        [JsonProperty("rankValue")]
        public short RankValue { get; internal set; }
    }
}
