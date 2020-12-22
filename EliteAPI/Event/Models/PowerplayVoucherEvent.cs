using System;
using System.Collections.Generic;
using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class PowerplayVoucherEvent : EventBase
    {
        internal PowerplayVoucherEvent()
        {
        }

        [JsonProperty("Power")] public string Power { get; private set; }

        [JsonProperty("Systems")] public IReadOnlyList<string> Systems { get; private set; }
    }

    public partial class PowerplayVoucherEvent
    {
        public static PowerplayVoucherEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<PowerplayVoucherEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<PowerplayVoucherEvent> PowerplayVoucherEvent;

        internal void InvokePowerplayVoucherEvent(PowerplayVoucherEvent arg)
        {
            PowerplayVoucherEvent?.Invoke(this, arg);
        }
    }
}