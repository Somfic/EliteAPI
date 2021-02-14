using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class ResurrectEvent : EventBase<ResurrectEvent>
    {
        internal ResurrectEvent() { }

        [JsonProperty("Option")]
        public string Option { get; private set; }

        [JsonProperty("Cost")]
        public long Cost { get; private set; }

        [JsonProperty("Bankrupt")]
        public bool Bankrupt { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<ResurrectEvent> ResurrectEvent;

    }
}