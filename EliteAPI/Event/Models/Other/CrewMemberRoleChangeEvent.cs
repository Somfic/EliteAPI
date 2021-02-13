using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
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
        public static CrewMemberRoleChangeEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CrewMemberRoleChangeEvent>(json);
        }
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