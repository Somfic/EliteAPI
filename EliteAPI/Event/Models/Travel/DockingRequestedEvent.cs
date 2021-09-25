using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class DockingRequestedEvent : EventBase<DockingRequestedEvent>
    {
        internal DockingRequestedEvent() { }

        [JsonProperty("MarketID")]
        public string MarketId { get; private set; }

        [JsonProperty("StationName")]
        public string StationName { get; private set; }

        [JsonProperty("StationType")]
        public string StationType { get; private set; }
        
        [JsonProperty("LandingPads")]
        public LandingPadsInfo LandingPads { get; private set; }

        [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
        public class LandingPadsInfo
        {
            internal LandingPadsInfo() { }
           
            [JsonProperty("Small")]
            public int Small { get; private set; }
           
            [JsonProperty("Medium")]
            public int Medium { get; private set; }
           
            [JsonProperty("Large")]
            public int Large { get; private set; }
        }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<DockingRequestedEvent> DockingRequestedEvent;

        internal void InvokeDockingRequestedEvent(DockingRequestedEvent arg)
        {
            DockingRequestedEvent?.Invoke(this, arg);
        }
    }
}