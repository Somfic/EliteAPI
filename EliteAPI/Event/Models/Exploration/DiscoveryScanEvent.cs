using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class DiscoveryScanEvent : EventBase
    {
        internal DiscoveryScanEvent() { }

        [JsonProperty("SystemAddress")]
        public string SystemAddress { get; internal set; }

        [JsonProperty("Bodies")]
        public long Bodies { get; internal set; }
    }

    public partial class DiscoveryScanEvent
    {
        public static DiscoveryScanEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<DiscoveryScanEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<DiscoveryScanEvent> DiscoveryScanEvent;

        internal void InvokeDiscoveryScanEvent(DiscoveryScanEvent arg)
        {
            DiscoveryScanEvent?.Invoke(this, arg);
        }
    }
}