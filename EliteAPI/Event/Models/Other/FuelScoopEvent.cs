using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class FuelScoopEvent : EventBase<FuelScoopEvent>
    {
        internal FuelScoopEvent() { }

        [JsonProperty("Scooped")]
        public double Scooped { get; private set; }

        [JsonProperty("Total")]
        public double Total { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<FuelScoopEvent> FuelScoopEvent;

        internal void InvokeFuelScoopEvent(FuelScoopEvent arg)
        {
            FuelScoopEvent?.Invoke(this, arg);
        }
    }
}