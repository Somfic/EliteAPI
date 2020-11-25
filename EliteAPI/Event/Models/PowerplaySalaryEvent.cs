
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class PowerplaySalaryEvent : EventBase
    {
        internal PowerplaySalaryEvent() { }

        [JsonProperty("Power")]
        public string Power { get; private set; }

        [JsonProperty("Amount")]
        public long Amount { get; private set; }
    }

    public partial class PowerplaySalaryEvent
    {
        public static PowerplaySalaryEvent FromJson(string json) => JsonConvert.DeserializeObject<PowerplaySalaryEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<PowerplaySalaryEvent> PowerplaySalaryEvent;
        internal void InvokePowerplaySalaryEvent(PowerplaySalaryEvent arg) => PowerplaySalaryEvent?.Invoke(this, arg);
    }
}
