
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class LaunchSrvEvent : EventBase
    {
        internal LaunchSrvEvent() { }

        [JsonProperty("Loadout")]
        public string Loadout { get; private set; }

        [JsonProperty("ID")]
        public long Id { get; private set; }

        [JsonProperty("PlayerControlled")]
        public bool PlayerControlled { get; private set; }
    }

    public partial class LaunchSrvEvent
    {
        public static LaunchSrvEvent FromJson(string json) => JsonConvert.DeserializeObject<LaunchSrvEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<LaunchSrvEvent> LaunchSrvEvent;
        internal void InvokeLaunchSrvEvent(LaunchSrvEvent arg) => LaunchSrvEvent?.Invoke(this, arg);
    }
}
