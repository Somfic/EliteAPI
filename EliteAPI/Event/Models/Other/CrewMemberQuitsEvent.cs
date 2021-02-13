using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public partial class CrewMemberQuitsEvent : EventBase
    {
        internal CrewMemberQuitsEvent() { }

        [JsonProperty("Crew")]
        public string Crew { get; private set; }
    }

    public partial class CrewMemberQuitsEvent
    {
        public static CrewMemberQuitsEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CrewMemberQuitsEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<CrewMemberQuitsEvent> CrewMemberQuitsEvent;

        internal void InvokeCrewMemberQuitsEvent(CrewMemberQuitsEvent arg)
        {
            CrewMemberQuitsEvent?.Invoke(this, arg);
        }
    }
}