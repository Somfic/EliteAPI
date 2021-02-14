using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class FssDiscoveryScanEvent : EventBase<FssDiscoveryScanEvent>
    {
        internal FssDiscoveryScanEvent() { }

        [JsonProperty("Progress")]
        public double Progress { get; private set; }

        [JsonProperty("BodyCount")]
        public long BodyCount { get; private set; }

        [JsonProperty("NonBodyCount")]
        public long NonBodyCount { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<FssDiscoveryScanEvent> FssDiscoveryScanEvent;

        internal void InvokeFssDiscoveryScanEvent(FssDiscoveryScanEvent arg)
        {
            FssDiscoveryScanEvent?.Invoke(this, arg);
        }
    }
}