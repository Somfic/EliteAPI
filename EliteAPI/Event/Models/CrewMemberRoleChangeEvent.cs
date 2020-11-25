
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class CrewMemberRoleChangeEvent : EventBase
    {
        internal CrewMemberRoleChangeEvent() { }

        [JsonProperty("Crew")]
        public string Crew { get; private set; }

        [JsonProperty("Role")]
        public string Role { get; private set; }
    }

    public partial class CrewMemberRoleChangeEvent
    {
        public static CrewMemberRoleChangeEvent FromJson(string json) => JsonConvert.DeserializeObject<CrewMemberRoleChangeEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<CrewMemberRoleChangeEvent> CrewMemberRoleChangeEvent;
        internal void InvokeCrewMemberRoleChangeEvent(CrewMemberRoleChangeEvent arg) => CrewMemberRoleChangeEvent?.Invoke(this, arg);
    }
}
