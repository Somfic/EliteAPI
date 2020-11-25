
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class PowerplayLeaveEvent : EventBase
    {
        internal PowerplayLeaveEvent() { }

        [JsonProperty("Power")]
        public string Power { get; private set; }
    }

    public partial class PowerplayLeaveEvent
    {
        public static PowerplayLeaveEvent FromJson(string json) => JsonConvert.DeserializeObject<PowerplayLeaveEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<PowerplayLeaveEvent> PowerplayLeaveEvent;
        internal void InvokePowerplayLeaveEvent(PowerplayLeaveEvent arg) => PowerplayLeaveEvent?.Invoke(this, arg);
    }
}
