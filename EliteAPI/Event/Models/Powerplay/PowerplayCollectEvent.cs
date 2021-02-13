using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class PowerplayCollectEvent : EventBase
    {
        internal PowerplayCollectEvent() { }

        [JsonProperty("Power")]
        public string Power { get; private set; }

        [JsonProperty("Type")]
        public string Type { get; private set; }

        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; private set; }

        [JsonProperty("Count")]
        public long Count { get; private set; }
    }

    public partial class PowerplayCollectEvent
    {
        public static PowerplayCollectEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<PowerplayCollectEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<PowerplayCollectEvent> PowerplayCollectEvent;

        internal void InvokePowerplayCollectEvent(PowerplayCollectEvent arg)
        {
            PowerplayCollectEvent?.Invoke(this, arg);
        }
    }
}