using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class CommunityGoalRewardEvent : EventBase
    {
        internal CommunityGoalRewardEvent() { }

        [JsonProperty("Name")]
        public string Name { get; private set; }

        [JsonProperty("System")]
        public string System { get; private set; }

        [JsonProperty("Reward")]
        public long Reward { get; private set; }
    }

    public partial class CommunityGoalRewardEvent
    {
        public static CommunityGoalRewardEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CommunityGoalRewardEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<CommunityGoalRewardEvent> CommunityGoalRewardEvent;

        internal void InvokeCommunityGoalRewardEvent(CommunityGoalRewardEvent arg)
        {
            CommunityGoalRewardEvent?.Invoke(this, arg);
        }
    }
}