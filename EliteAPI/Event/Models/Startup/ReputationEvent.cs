using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class ReputationEvent : EventBase<ReputationEvent>
    {
        internal ReputationEvent() { }

        [JsonProperty("Empire")]
        public double Empire { get; private set; }

        [JsonProperty("Federation")]
        public double Federation { get; private set; }

        [JsonProperty("Independent")]
        public double Independent { get; private set; }

        [JsonProperty("Alliance")]
        public double Alliance { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<ReputationEvent> ReputationEvent;

    }
}