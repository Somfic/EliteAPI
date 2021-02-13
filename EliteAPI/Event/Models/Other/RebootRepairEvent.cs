using System;
using System.Collections.Generic;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public partial class RebootRepairEvent : EventBase
    {
        internal RebootRepairEvent() { }

        [JsonProperty("Modules")]
        public IReadOnlyList<string> Modules { get; private set; }
    }

    public partial class RebootRepairEvent
    {
        public static RebootRepairEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<RebootRepairEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<RebootRepairEvent> RebootRepairEvent;

        internal void InvokeRebootRepairEvent(RebootRepairEvent arg)
        {
            RebootRepairEvent?.Invoke(this, arg);
        }
    }
}