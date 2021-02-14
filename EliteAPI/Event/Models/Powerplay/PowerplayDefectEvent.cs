using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class PowerplayDefectEvent : EventBase<PowerplayDefectEvent>
    {
        internal PowerplayDefectEvent() { }

        [JsonProperty("FromPower")]
        public string FromPower { get; internal set; }

        [JsonProperty("ToPower")]
        public string ToPower { get; internal set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<PowerplayDefectEvent> PowerplayDefectEvent;

    }
}