using System;
using Newtonsoft.Json;

namespace EliteAPI.Inara.Events
{
    public class AddCommanderFriend : IInaraEventData
    {
        public AddCommanderFriend(string commanderName)
        {
            CommanderName = commanderName;
        }

        [JsonProperty("commanderName")]
        public string CommanderName { get; set; }

        [JsonProperty("gamePlatform")]
        public string GamePlatform { get { return "pc"; } }
    }
}
