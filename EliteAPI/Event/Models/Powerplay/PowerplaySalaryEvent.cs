using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class PowerplaySalaryEvent : EventBase<PowerplaySalaryEvent>
    {
        internal PowerplaySalaryEvent() { }

        [JsonProperty("Power")]
        public string Power { get; private set; }

        [JsonProperty("Amount")]
        public long Amount { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<PowerplaySalaryEvent> PowerplaySalaryEvent;

        internal void InvokePowerplaySalaryEvent(PowerplaySalaryEvent arg)
        {
            PowerplaySalaryEvent?.Invoke(this, arg);
        }
    }
}