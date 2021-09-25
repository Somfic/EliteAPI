using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class SupercruiseExitEvent : EventBase<SupercruiseExitEvent>
    {
        internal SupercruiseExitEvent() { }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; private set; }

        [JsonProperty("SystemAddress")]
        public string SystemAddress { get; private set; }
        
        [JsonProperty("Taxi")]
        public bool IsTaxi { get; private set; }

        [JsonProperty("Multicrew")]
        public bool IsMulticrew { get; private set; }
        
        [JsonProperty("Body")]
        public string Body { get; private set; }

        [JsonProperty("BodyID")]
        public string BodyId { get; private set; }

        [JsonProperty("BodyType")]
        public string BodyType { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<SupercruiseExitEvent> SupercruiseExitEvent;

        internal void InvokeSupercruiseExitEvent(SupercruiseExitEvent arg)
        {
            SupercruiseExitEvent?.Invoke(this, arg);
        }
    }
}