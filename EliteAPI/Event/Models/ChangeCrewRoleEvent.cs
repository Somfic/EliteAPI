
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class ChangeCrewRoleEvent : EventBase
    {
        internal ChangeCrewRoleEvent() { }

        [JsonProperty("Role")]
        public string Role { get; private set; }
    }

    public partial class ChangeCrewRoleEvent
    {
        public static ChangeCrewRoleEvent FromJson(string json) => JsonConvert.DeserializeObject<ChangeCrewRoleEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<ChangeCrewRoleEvent> ChangeCrewRoleEvent;
        internal void InvokeChangeCrewRoleEvent(ChangeCrewRoleEvent arg) => ChangeCrewRoleEvent?.Invoke(this, arg);
    }
}
