using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class PowerplayDeliverEvent : EventBase
    {
        internal PowerplayDeliverEvent() { }

        [JsonProperty("Power")]
        public string Power { get; private set; }

        [JsonProperty("Type")]
        public string Type { get; private set; }

        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; private set; }

        [JsonProperty("Count")]
        public long Count { get; private set; }
    }

    public partial class PowerplayDeliverEvent
    {
        public static PowerplayDeliverEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<PowerplayDeliverEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<PowerplayDeliverEvent> PowerplayDeliverEvent;

        internal void InvokePowerplayDeliverEvent(PowerplayDeliverEvent arg)
        {
            PowerplayDeliverEvent?.Invoke(this, arg);
        }
    }
}