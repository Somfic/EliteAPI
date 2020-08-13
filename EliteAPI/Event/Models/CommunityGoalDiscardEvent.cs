using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class CommunityGoalDiscardEvent : EventBase
    {
        internal CommunityGoalDiscardEvent() { }
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("System")]
        public string System { get; internal set; }

        
    }
}