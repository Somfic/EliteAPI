using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class ReservoirReplenishedEvent : EventBase
    {
        internal ReservoirReplenishedEvent() { }

        [JsonProperty("FuelMain")]
        public double FuelMain { get; private set; }

        [JsonProperty("FuelReservoir")]
        public double FuelReservoir { get; private set; }
    }

    public partial class ReservoirReplenishedEvent
    {
        public static ReservoirReplenishedEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ReservoirReplenishedEvent>(json);
        }
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