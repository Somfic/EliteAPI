using Newtonsoft.Json;
namespace EliteAPI.Inara.Events
{
    public class DelCommanderFriend : IInaraEventData
    {
        public DelCommanderFriend(string commanderName)
        {
            CommanderName = commanderName;
        }
        [JsonProperty("commanderName")]
        public string CommanderName { get; set; }
        [JsonProperty("gamePlatform")]
        public string GamePlatform { get { return "pc"; } }
    }
}
