using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class PowerplayJoinEvent : EventBase<PowerplayJoinEvent>
    {
        internal PowerplayJoinEvent() { }

        [JsonProperty("Power")]
        public string Power { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<PowerplayJoinEvent> PowerplayJoinEvent;

        internal void InvokePowerplayJoinEvent(PowerplayJoinEvent arg)
        {
            PowerplayJoinEvent?.Invoke(this, arg);
        }
    }
}