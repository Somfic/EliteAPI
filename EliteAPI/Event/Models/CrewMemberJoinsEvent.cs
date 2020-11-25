
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class CrewMemberJoinsEvent : EventBase
    {
        internal CrewMemberJoinsEvent() { }

        [JsonProperty("Crew")]
        public string Crew { get; private set; }
    }

    public partial class CrewMemberJoinsEvent
    {
        public static CrewMemberJoinsEvent FromJson(string json) => JsonConvert.DeserializeObject<CrewMemberJoinsEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<CrewMemberJoinsEvent> CrewMemberJoinsEvent;
        internal void InvokeCrewMemberJoinsEvent(CrewMemberJoinsEvent arg) => CrewMemberJoinsEvent?.Invoke(this, arg);
    }
}
