using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class HullDamageEvent : EventBase<HullDamageEvent>
    {
        internal HullDamageEvent() { }

        [JsonProperty("Health")]
        public double Health { get; private set; }

        [JsonProperty("PlayerPilot")]
        public bool PlayerPilot { get; private set; }

        [JsonProperty("Fighter")]
        public bool Fighter { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<HullDamageEvent> HullDamageEvent;

    }
}