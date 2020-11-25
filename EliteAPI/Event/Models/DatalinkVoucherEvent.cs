
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class DatalinkVoucherEvent : EventBase
    {
        internal DatalinkVoucherEvent() { }

        [JsonProperty("Reward")]
        public long Reward { get; private set; }

        [JsonProperty("VictimFaction")]
        public string VictimFaction { get; private set; }

        [JsonProperty("PayeeFaction")]
        public string PayeeFaction { get; private set; }
    }

    public partial class DatalinkVoucherEvent
    {
        public static DatalinkVoucherEvent FromJson(string json) => JsonConvert.DeserializeObject<DatalinkVoucherEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<DatalinkVoucherEvent> DatalinkVoucherEvent;
        internal void InvokeDatalinkVoucherEvent(DatalinkVoucherEvent arg) => DatalinkVoucherEvent?.Invoke(this, arg);
    }
}
