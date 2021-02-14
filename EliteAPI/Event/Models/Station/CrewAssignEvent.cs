using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class CrewAssignEvent : EventBase<CrewAssignEvent>
    {
        internal CrewAssignEvent() { }

        [JsonProperty("Name")]
        public string Name { get; private set; }

        [JsonProperty("CrewID")]
        public string CrewId { get; private set; }

        [JsonProperty("Role")]
        public string Role { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<CrewAssignEvent> CrewAssignEvent;

    }
}