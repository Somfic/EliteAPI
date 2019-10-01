using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;

namespace EliteAPI.Inara.Events
{
    public class SetCommanderRankPower : IInaraEventData
    {
        public SetCommanderRankPower(string powerName, long rankValue)
        {
            PowerName = powerName;
            RankValue = rankValue;
        }

        [JsonProperty("powerName")]
        public string PowerName { get; internal set; }

        [Range(0, 5)]
        [JsonProperty("rankValue")]
        public long RankValue { get; internal set; }
    }
}
