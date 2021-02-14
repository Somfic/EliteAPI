using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class DockingDeniedEvent : EventBase<DockingDeniedEvent>
    {
        internal DockingDeniedEvent() { }

        [JsonProperty("Reason")]
        public string Reason { get; private set; }

        [JsonProperty("MarketID")]
        public string MarketId { get; private set; }

        [JsonProperty("StationName")]
        public string StationName { get; private set; }

        [JsonProperty("StationType")]
        public string StationType { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<DockingDeniedEvent> DockingDeniedEvent;

        internal void InvokeDockingDeniedEvent(DockingDeniedEvent arg)
        {
            DockingDeniedEvent?.Invoke(this, arg);
        }
    }
}