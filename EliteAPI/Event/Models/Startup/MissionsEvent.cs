using System;
using System.Collections.Generic;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public partial class MissionsEvent : EventBase
    {
        internal MissionsEvent() { }

        [JsonProperty("Active")]
        public IReadOnlyList<object> Active { get; private set; }

        [JsonProperty("Failed")]
        public IReadOnlyList<object> Failed { get; private set; }

        [JsonProperty("Complete")]
        public IReadOnlyList<object> Complete { get; private set; }
    }

    public partial class MissionsEvent
    {
        public static MissionsEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<MissionsEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<MissionsEvent> MissionsEvent;

        internal void InvokeMissionsEvent(MissionsEvent arg)
        {
            MissionsEvent?.Invoke(this, arg);
        }
    }
}