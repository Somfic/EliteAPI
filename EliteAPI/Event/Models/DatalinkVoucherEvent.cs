using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
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
        public static DatalinkVoucherEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<DatalinkVoucherEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<DatalinkVoucherEvent> DatalinkVoucherEvent;

        internal void InvokeDatalinkVoucherEvent(DatalinkVoucherEvent arg)
        {
            DatalinkVoucherEvent?.Invoke(this, arg);
        }
    }
}