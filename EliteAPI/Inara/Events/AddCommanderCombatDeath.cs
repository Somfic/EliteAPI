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
        public string StarSystemName { get; internal set; }

        [JsonProperty("opponentName")]
        public string OpponentName { get; internal set; }

        [JsonProperty("wingOpponentNames")]
        public List<string> WingOpponentNames { get; internal set; }

        [JsonProperty("isPlayer")]
        public bool IsPlayer { get; internal set; }
    }
}
