
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


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
        public static CommunityGoalRewardEvent FromJson(string json) => JsonConvert.DeserializeObject<CommunityGoalRewardEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<CommunityGoalRewardEvent> CommunityGoalRewardEvent;
        internal void InvokeCommunityGoalRewardEvent(CommunityGoalRewardEvent arg) => CommunityGoalRewardEvent?.Invoke(this, arg);
    }
}
