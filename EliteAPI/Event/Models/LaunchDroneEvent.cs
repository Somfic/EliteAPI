
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class LaunchDroneEvent : EventBase
    {
        internal LaunchDroneEvent() { }

        [JsonProperty("Type")]
        public string Type { get; private set; }
    }

    public partial class LaunchDroneEvent
    {
        public static LaunchDroneEvent FromJson(string json) => JsonConvert.DeserializeObject<LaunchDroneEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<LaunchDroneEvent> LaunchDroneEvent;
        internal void InvokeLaunchDroneEvent(LaunchDroneEvent arg) => LaunchDroneEvent?.Invoke(this, arg);
    }
}
