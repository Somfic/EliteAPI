using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public partial class HeatDamageEvent : EventBase
    {
        internal HeatDamageEvent() { }
    }

    public partial class HeatDamageEvent
    {
        public static HeatDamageEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<HeatDamageEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<HeatDamageEvent> HeatDamageEvent;

        internal void InvokeHeatDamageEvent(HeatDamageEvent arg)
        {
            HeatDamageEvent?.Invoke(this, arg);
        }
    }
}