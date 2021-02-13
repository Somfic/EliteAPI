using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class HullDamageEvent : EventBase
    {
        internal HullDamageEvent() { }

        [JsonProperty("Health")]
        public double Health { get; private set; }

        [JsonProperty("PlayerPilot")]
        public bool PlayerPilot { get; private set; }

        [JsonProperty("Fighter")]
        public bool Fighter { get; private set; }
    }

    public partial class HullDamageEvent
    {
        public static HullDamageEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<HullDamageEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<HullDamageEvent> HullDamageEvent;

        internal void InvokeHullDamageEvent(HullDamageEvent arg)
        {
            HullDamageEvent?.Invoke(this, arg);
        }
    }
}