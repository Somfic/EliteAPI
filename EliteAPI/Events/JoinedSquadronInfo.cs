using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class JoinedSquadronInfo : EventBase
    {
        [JsonProperty("SquadronName")]
        public string SquadronName { get; internal set; }

        internal static JoinedSquadronInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeJoinedSquadronEvent(JsonConvert.DeserializeObject<JoinedSquadronInfo>(json, JsonSettings.Settings));
        }
    }
}