using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class CommunityGoalJoinInfo : EventBase
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("System")]
        public string System { get; internal set; }

        internal static CommunityGoalJoinInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeCommunityGoalJoinEvent(JsonConvert.DeserializeObject<CommunityGoalJoinInfo>(json, JsonSettings.Settings));
        }
    }
}