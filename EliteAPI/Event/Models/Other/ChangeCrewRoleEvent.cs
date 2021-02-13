using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public partial class ChangeCrewRoleEvent : EventBase
    {
        internal ChangeCrewRoleEvent() { }

        [JsonProperty("Role")]
        public string Role { get; private set; }
    }

    public partial class ChangeCrewRoleEvent
    {
        public static ChangeCrewRoleEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ChangeCrewRoleEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<ChangeCrewRoleEvent> ChangeCrewRoleEvent;

        internal void InvokeChangeCrewRoleEvent(ChangeCrewRoleEvent arg)
        {
            ChangeCrewRoleEvent?.Invoke(this, arg);
        }
    }
}