
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class CrewMemberQuitsEvent : EventBase
    {
        internal CrewMemberQuitsEvent() { }

        [JsonProperty("Crew")]
        public string Crew { get; private set; }
    }

    public partial class CrewMemberQuitsEvent
    {
        public static CrewMemberQuitsEvent FromJson(string json) => JsonConvert.DeserializeObject<CrewMemberQuitsEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<CrewMemberQuitsEvent> CrewMemberQuitsEvent;
        internal void InvokeCrewMemberQuitsEvent(CrewMemberQuitsEvent arg) => CrewMemberQuitsEvent?.Invoke(this, arg);
    }
}
