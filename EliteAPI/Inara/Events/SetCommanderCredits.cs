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
        public long CommanderCredits { get; internal set; }
        [JsonProperty("commanderAssets")]
        public long CommanderAssets { get; internal set; }
        [JsonProperty("commanderLoan")]
        public long CommanderLoan { get; internal set; }
    }
}
