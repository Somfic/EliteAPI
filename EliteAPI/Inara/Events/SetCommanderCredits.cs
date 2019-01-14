using Newtonsoft.Json;

namespace EliteAPI.Inara.Events
{
    public class SetCommanderCredits : IInaraEventData
    {
        public SetCommanderCredits(int commanderCredits)
        {
            CommanderCredits = commanderCredits;
        }

        [JsonProperty("commanderCredits")]
        public int CommanderCredits { get; set; }

        [JsonProperty("commanderAssets")]
        public int CommanderAssets { get; set; }

        [JsonProperty("commanderLoan")]
        public int CommanderLoan { get; set; }
    }
}
