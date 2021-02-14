using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class CrewMemberRoleChangeEvent : EventBase<CrewMemberRoleChangeEvent>
    {
        internal CrewMemberRoleChangeEvent() { }

        [JsonProperty("Crew")]
        public string Crew { get; private set; }

        [JsonProperty("Role")]
        public string Role { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<CrewMemberRoleChangeEvent> CrewMemberRoleChangeEvent;

        internal void InvokeCrewMemberRoleChangeEvent(CrewMemberRoleChangeEvent arg)
        {
            CrewMemberRoleChangeEvent?.Invoke(this, arg);
        }
    }
}