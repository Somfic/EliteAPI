
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class PowerplayJoinEvent : EventBase
    {
        internal PowerplayJoinEvent() { }

        [JsonProperty("Power")]
        public string Power { get; private set; }
    }

    public partial class PowerplayJoinEvent
    {
        public static PowerplayJoinEvent FromJson(string json) => JsonConvert.DeserializeObject<PowerplayJoinEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<PowerplayJoinEvent> PowerplayJoinEvent;
        internal void InvokePowerplayJoinEvent(PowerplayJoinEvent arg) => PowerplayJoinEvent?.Invoke(this, arg);
    }
}
