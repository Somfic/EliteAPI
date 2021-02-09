using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class DockingRequestedEvent : EventBase
    {
        internal DockingRequestedEvent() { }

        [JsonProperty("MarketID")]
        public string MarketId { get; private set; }

        [JsonProperty("StationName")]
        public string StationName { get; private set; }

        [JsonProperty("StationType")]
        public string StationType { get; private set; }
    }

    public partial class DockingRequestedEvent
    {
        public static DockingRequestedEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<DockingRequestedEvent>(json);
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