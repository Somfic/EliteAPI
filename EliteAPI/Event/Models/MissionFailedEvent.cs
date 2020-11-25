
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class MissionFailedEvent : EventBase
    {
        internal MissionFailedEvent() { }

        [JsonProperty("Name")]
        public string Name { get; private set; }

        [JsonProperty("MissionID")]
        public long MissionId { get; private set; }
    }

    public partial class MissionFailedEvent
    {
        public static MissionFailedEvent FromJson(string json) => JsonConvert.DeserializeObject<MissionFailedEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<MissionFailedEvent> MissionFailedEvent;
        internal void InvokeMissionFailedEvent(MissionFailedEvent arg) => MissionFailedEvent?.Invoke(this, arg);
    }
}
