using Newtonsoft.Json;

namespace EliteAPI.Inara.Events
{
    class AddCommanderCombatInterdicted : IInaraEventData
    {
        public AddCommanderCombatInterdicted(string starsystemName, string opponentName, bool isPlayer)
        {
            StarsystemName = starsystemName;
            OpponentName = opponentName;
            IsPlayer = isPlayer;
        }

        [JsonProperty("starsystemName")]
        public string StarsystemName { get; internal set; }

        [JsonProperty("opponentName")]
        public string OpponentName { get; internal set; }

        [JsonProperty("isPlayer")]
        public bool IsPlayer { get; internal set; }

        [JsonProperty("isSubmit")]
        public bool IsSubmit { get; internal set; }
    }
}
