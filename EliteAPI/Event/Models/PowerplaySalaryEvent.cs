using System;
using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class PowerplaySalaryEvent : EventBase
    {
        internal PowerplaySalaryEvent()
        {
        }

        [JsonProperty("Power")] public string Power { get; private set; }

        [JsonProperty("Amount")] public long Amount { get; private set; }
    }

    public partial class PowerplaySalaryEvent
    {
        public static PowerplaySalaryEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<PowerplaySalaryEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<PowerplaySalaryEvent> PowerplaySalaryEvent;

        internal void InvokePowerplaySalaryEvent(PowerplaySalaryEvent arg)
        {
            PowerplaySalaryEvent?.Invoke(this, arg);
        }
    }
}