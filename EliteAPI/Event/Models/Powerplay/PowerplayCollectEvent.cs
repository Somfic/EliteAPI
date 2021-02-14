using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class PowerplayCollectEvent : EventBase<PowerplayCollectEvent>
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

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<PowerplayCollectEvent> PowerplayCollectEvent;

    }
}