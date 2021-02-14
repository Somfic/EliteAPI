using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class SendTextEvent : EventBase<SendTextEvent>
    {
        internal SendTextEvent() { }

        [JsonProperty("To")]
        public string To { get; private set; }

        [JsonProperty("Message")]
        public string Message { get; private set; }

        [JsonProperty("Sent")]
        public bool Sent { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<SendTextEvent> SendTextEvent;

    }
}