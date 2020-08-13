using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class CommunityGoalJoinEvent : EventBase
    {
        internal CommunityGoalJoinEvent() { }
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("System")]
        public string System { get; internal set; }

        
    }
}