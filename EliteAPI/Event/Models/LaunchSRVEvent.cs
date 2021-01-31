using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class LaunchSrvEvent : EventBase
    {
        internal LaunchSrvEvent() { }

        [JsonProperty("Loadout")]
        public string Loadout { get; private set; }

        [JsonProperty("ID")]
        public string Id { get; private set; }

        [JsonProperty("PlayerControlled")]
        public bool PlayerControlled { get; private set; }
    }

    public partial class LaunchSrvEvent
    {
        public static LaunchSrvEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<LaunchSrvEvent>(json);
        }
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