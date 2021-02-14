using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class LaunchSrvEvent : EventBase<LaunchSrvEvent>
    {
        internal LaunchSrvEvent() { }

        [JsonProperty("Loadout")]
        public string Loadout { get; private set; }

        [JsonProperty("ID")]
        public string Id { get; private set; }

        [JsonProperty("PlayerControlled")]
        public bool PlayerControlled { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<LaunchSrvEvent> LaunchSrvEvent;

        internal void InvokeLaunchSrvEvent(LaunchSrvEvent arg)
        {
            LaunchSrvEvent?.Invoke(this, arg);
        }
    }
}