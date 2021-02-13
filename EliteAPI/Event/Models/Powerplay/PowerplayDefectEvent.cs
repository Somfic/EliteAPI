using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public partial class PowerplayDefectEvent : EventBase
    {
        internal PowerplayDefectEvent() { }

        [JsonProperty("FromPower")]
        public string FromPower { get; internal set; }

        [JsonProperty("ToPower")]
        public string ToPower { get; internal set; }
    }

    public partial class PowerplayDefectEvent
    {
        public static PowerplayDefectEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<PowerplayDefectEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<PowerplayDefectEvent> PowerplayDefectEvent;

        internal void InvokePowerplayDefectEvent(PowerplayDefectEvent arg)
        {
            PowerplayDefectEvent?.Invoke(this, arg);
        }
    }
}