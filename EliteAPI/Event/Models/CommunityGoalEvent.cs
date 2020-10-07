using System.Collections.Generic;
using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class CommunityGoalEvent : EventBase
    {
        internal CommunityGoalEvent() { }

        public static CommunityGoalEvent FromJson(string json) => JsonConvert.DeserializeObject<CommunityGoalEvent>(json);


        [JsonProperty("CurrentGoals")]
        public List<CurrentGoal> CurrentGoals { get; internal set; }

        
    }
}