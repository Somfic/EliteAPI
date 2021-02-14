using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class DatalinkVoucherEvent : EventBase<DatalinkVoucherEvent>
    {
        internal DatalinkVoucherEvent() { }

        [JsonProperty("Reward")]
        public long Reward { get; private set; }

        [JsonProperty("VictimFaction")]
        public string VictimFaction { get; private set; }

        [JsonProperty("PayeeFaction")]
        public string PayeeFaction { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<DatalinkVoucherEvent> DatalinkVoucherEvent;

    }
}