using Newtonsoft.Json;
namespace EliteAPI.Inara.Events
{
    public class AddCommanderCombatKill : IInaraEventData
    {
        public AddCommanderCombatKill(string starsystemName, string opponentName)
        {
            StarsystemName = starsystemName;
            OpponentName = opponentName;
        }
        [JsonProperty("starsystemName")]
        public string StarsystemName { get; internal set; }
        [JsonProperty("opponentName")]
        public string OpponentName { get; internal set; }
    }
}
