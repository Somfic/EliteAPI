
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class MissionAbandonedEvent : EventBase
    {
        internal MissionAbandonedEvent() { }

        [JsonProperty("Name")]
        public string Name { get; private set; }

        [JsonProperty("MissionID")]
        public long MissionId { get; private set; }
    }

    public partial class MissionAbandonedEvent
    {
        public static MissionAbandonedEvent FromJson(string json) => JsonConvert.DeserializeObject<MissionAbandonedEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<MissionAbandonedEvent> MissionAbandonedEvent;
        internal void InvokeMissionAbandonedEvent(MissionAbandonedEvent arg) => MissionAbandonedEvent?.Invoke(this, arg);
    }
}
