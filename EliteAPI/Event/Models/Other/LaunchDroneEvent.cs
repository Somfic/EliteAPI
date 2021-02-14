using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class LaunchDroneEvent : EventBase<LaunchDroneEvent>
    {
        internal LaunchDroneEvent() { }

        [JsonProperty("Type")]
        public string Type { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<LaunchDroneEvent> LaunchDroneEvent;

        internal void InvokeLaunchDroneEvent(LaunchDroneEvent arg)
        {
            LaunchDroneEvent?.Invoke(this, arg);
        }
    }
}