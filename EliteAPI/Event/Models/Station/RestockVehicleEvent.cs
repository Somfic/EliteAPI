using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class RestockVehicleEvent : EventBase<RestockVehicleEvent>
    {
        internal RestockVehicleEvent() { }

        [JsonProperty("Type")]
        public string Type { get; private set; }

        [JsonProperty("Loadout")]
        public string Loadout { get; private set; }

        [JsonProperty("Cost")]
        public long Cost { get; private set; }

        [JsonProperty("Count")]
        public long Count { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<RestockVehicleEvent> RestockVehicleEvent;

        internal void InvokeRestockVehicleEvent(RestockVehicleEvent arg)
        {
            RestockVehicleEvent?.Invoke(this, arg);
        }
    }
}