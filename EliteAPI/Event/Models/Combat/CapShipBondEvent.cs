using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class CapShipBondEvent : EventBase
    {
        internal CapShipBondEvent() { }

        [JsonProperty("Reward")]
        public long Reward { get; internal set; }

        [JsonProperty("RewardingFaction")]
        public string RewardingFaction { get; internal set; }
        
        [JsonProperty("VictimFaction")]
        public string VictimFaction { get; internal set; }
    }

    public partial class CapShipBondEvent
    {
        public static CapShipBondEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CapShipBondEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<CapShipBondEvent> CapShipBondEvent;

        internal void InvokeCapShipBondEvent(CapShipBondEvent arg)
        {
            CapShipBondEvent?.Invoke(this, arg);
        }
    }
}