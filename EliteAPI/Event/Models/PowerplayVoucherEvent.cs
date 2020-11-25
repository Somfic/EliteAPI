
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class PowerplayVoucherEvent : EventBase
    {
        internal PowerplayVoucherEvent() { }

        [JsonProperty("Power")]
        public string Power { get; private set; }

        [JsonProperty("Systems")]
        public IReadOnlyList<string> Systems { get; private set; }
    }

    public partial class PowerplayVoucherEvent
    {
        public static PowerplayVoucherEvent FromJson(string json) => JsonConvert.DeserializeObject<PowerplayVoucherEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<PowerplayVoucherEvent> PowerplayVoucherEvent;
        internal void InvokePowerplayVoucherEvent(PowerplayVoucherEvent arg) => PowerplayVoucherEvent?.Invoke(this, arg);
    }
}
