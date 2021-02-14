using System;
using System.Collections.Generic;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class RebootRepairEvent : EventBase<RebootRepairEvent>
    {
        internal RebootRepairEvent() { }

        [JsonProperty("Modules")]
        public IReadOnlyList<string> Modules { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<RebootRepairEvent> RebootRepairEvent;

    }
}