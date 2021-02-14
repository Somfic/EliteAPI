using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class ReservoirReplenishedEvent : EventBase<ReservoirReplenishedEvent>
    {
        internal ReservoirReplenishedEvent() { }

        [JsonProperty("FuelMain")]
        public double FuelMain { get; private set; }

        [JsonProperty("FuelReservoir")]
        public double FuelReservoir { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<ReservoirReplenishedEvent> ReservoirReplenishedEvent;

        internal void InvokeReservoirReplenishedEvent(ReservoirReplenishedEvent arg)
        {
            ReservoirReplenishedEvent?.Invoke(this, arg);
        }
    }
}