using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class MissionFailedEvent : EventBase<MissionFailedEvent>
    {
        internal MissionFailedEvent() { }

        [JsonProperty("Name")]
        public string Name { get; private set; }

        [JsonProperty("MissionID")]
        public string MissionId { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<MissionFailedEvent> MissionFailedEvent;

    }
}