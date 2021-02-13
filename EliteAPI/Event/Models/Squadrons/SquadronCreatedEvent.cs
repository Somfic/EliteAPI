using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public partial class SquadronCreatedEvent : EventBase
    {
        internal SquadronCreatedEvent() { }

        [JsonProperty("SquadronName")]
        public string Name { get; internal set; }
    }

    public partial class SquadronCreatedEvent
    {
        public static SquadronCreatedEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<SquadronCreatedEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<SquadronCreatedEvent> SquadronCreatedEvent;

        internal void InvokeSquadronCreatedEvent(SquadronCreatedEvent arg)
        {
            SquadronCreatedEvent?.Invoke(this, arg);
        }
    }
}