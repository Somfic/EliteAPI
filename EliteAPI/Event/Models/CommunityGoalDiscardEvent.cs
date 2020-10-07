using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class CommunityGoalDiscardEvent : EventBase
    {
        internal CommunityGoalDiscardEvent() { }

        public static CommunityGoalDiscardEvent FromJson(string json) => JsonConvert.DeserializeObject<CommunityGoalDiscardEvent>(json);


        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("System")]
        public string System { get; internal set; }

        
    }
}