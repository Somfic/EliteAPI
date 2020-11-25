
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class CommunityGoalDiscardEvent : EventBase
    {
        internal CommunityGoalDiscardEvent() { }

        [JsonProperty("Name")]
        public string Name { get; private set; }

        [JsonProperty("System")]
        public string System { get; private set; }
    }

    public partial class CommunityGoalDiscardEvent
    {
        public static CommunityGoalDiscardEvent FromJson(string json) => JsonConvert.DeserializeObject<CommunityGoalDiscardEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<CommunityGoalDiscardEvent> CommunityGoalDiscardEvent;
        internal void InvokeCommunityGoalDiscardEvent(CommunityGoalDiscardEvent arg) => CommunityGoalDiscardEvent?.Invoke(this, arg);
    }
}
