using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Inara.Events
{
    public class AddCommanderCombatDeath : IInaraEventData
    {
        public AddCommanderCombatDeath(string starSystemName)
        {
            StarSystemName = starSystemName;
        }

        [JsonProperty("starsystemName")]
        public string StarSystemName { get; set; }

        [JsonProperty("opponentName")]
        public string OpponentName { get; set; }

        [JsonProperty("wingOpponentNames")]
        public List<string> WingOpponentNames { get; set; }

        [JsonProperty("isPlayer")]
        public bool IsPlayer { get; set; }
    }
}
