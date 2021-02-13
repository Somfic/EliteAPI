using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class UnderAttackEvent : EventBase
    {
        internal UnderAttackEvent() { }

        [JsonProperty("Target")]
        public string Target { get; private set; }
    }

    public partial class UnderAttackEvent
    {
        public static UnderAttackEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<UnderAttackEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<UnderAttackEvent> UnderAttackEvent;

        internal void InvokeUnderAttackEvent(UnderAttackEvent arg)
        {
            UnderAttackEvent?.Invoke(this, arg);
        }
    }
}