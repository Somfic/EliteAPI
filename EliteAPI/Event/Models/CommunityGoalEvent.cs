using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class CommunityGoalEvent : EventBase
    {
        internal CommunityGoalEvent() { }
        [JsonProperty("CurrentGoals")]
        public List<CurrentGoal> CurrentGoals { get; internal set; }

        
    }
}