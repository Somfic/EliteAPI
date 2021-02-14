using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class CrewMemberJoinsEvent : EventBase<CrewMemberJoinsEvent>
    {
        internal CrewMemberJoinsEvent() { }

        [JsonProperty("Crew")]
        public string Crew { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<CrewMemberJoinsEvent> CrewMemberJoinsEvent;

    }
}