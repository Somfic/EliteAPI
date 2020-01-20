using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class CommunityGoalDiscardInfo : EventBase
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("System")]
        public string System { get; internal set; }

        internal static CommunityGoalDiscardInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeCommunityGoalDiscardEvent(JsonConvert.DeserializeObject<CommunityGoalDiscardInfo>(json, JsonSettings.Settings));
        }
    }
}