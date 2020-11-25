using System;
using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class CommunityGoalJoinEvent : EventBase
    {
        internal CommunityGoalJoinEvent()
        {
        }

        [JsonProperty("Name")] public string Name { get; private set; }

        [JsonProperty("System")] public string System { get; private set; }
    }

    public partial class CommunityGoalJoinEvent
    {
        public static CommunityGoalJoinEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CommunityGoalJoinEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<CommunityGoalJoinEvent> CommunityGoalJoinEvent;

        internal void InvokeCommunityGoalJoinEvent(CommunityGoalJoinEvent arg)
        {
            CommunityGoalJoinEvent?.Invoke(this, arg);
        }
    }
}