
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class CommunityGoalJoinEvent : EventBase
    {
        internal CommunityGoalJoinEvent() { }

        [JsonProperty("Name")]
        public string Name { get; private set; }

        [JsonProperty("System")]
        public string System { get; private set; }
    }

    public partial class CommunityGoalJoinEvent
    {
        public static CommunityGoalJoinEvent FromJson(string json) => JsonConvert.DeserializeObject<CommunityGoalJoinEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<CommunityGoalJoinEvent> CommunityGoalJoinEvent;
        internal void InvokeCommunityGoalJoinEvent(CommunityGoalJoinEvent arg) => CommunityGoalJoinEvent?.Invoke(this, arg);
    }
}
