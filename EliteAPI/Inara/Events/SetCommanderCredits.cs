using Newtonsoft.Json;

namespace EliteAPI.Inara.Events
{
    public class SetCommanderCredits : IInaraEventData
    {
        public SetCommanderCredits(long commanderCredits)
        {
            CommanderCredits = commanderCredits;
        }

        [JsonProperty("commanderCredits")]
        public long CommanderCredits { get; set; }

        [JsonProperty("commanderAssets")]
        public long CommanderAssets { get; set; }

        [JsonProperty("commanderLoan")]
        public long CommanderLoan { get; set; }
    }
}
