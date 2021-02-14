using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class DiscoveryScanEvent : EventBase<DiscoveryScanEvent>
    {
        internal DiscoveryScanEvent() { }

        [JsonProperty("SystemAddress")]
        public string SystemAddress { get; internal set; }

        [JsonProperty("Bodies")]
        public long Bodies { get; internal set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<DiscoveryScanEvent> DiscoveryScanEvent;

    }
}