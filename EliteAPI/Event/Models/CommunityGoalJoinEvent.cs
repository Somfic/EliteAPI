using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class CommunityGoalJoinEvent : EventBase
    {
        internal CommunityGoalJoinEvent() { }

        public static CommunityGoalJoinEvent FromJson(string json) => JsonConvert.DeserializeObject<CommunityGoalJoinEvent>(json);


        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("System")]
        public string System { get; internal set; }

        
    }
}