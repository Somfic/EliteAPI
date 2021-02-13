using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class CrewMemberJoinsEvent : EventBase
    {
        internal CrewMemberJoinsEvent() { }

        [JsonProperty("Crew")]
        public string Crew { get; private set; }
    }

    public partial class CrewMemberJoinsEvent
    {
        public static CrewMemberJoinsEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CrewMemberJoinsEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<CrewMemberJoinsEvent> CrewMemberJoinsEvent;

        internal void InvokeCrewMemberJoinsEvent(CrewMemberJoinsEvent arg)
        {
            CrewMemberJoinsEvent?.Invoke(this, arg);
        }
    }
}