using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class ReceiveTextEvent : EventBase<ReceiveTextEvent>
    {
        internal ReceiveTextEvent() { }

        [JsonProperty("From")]
        public string From { get; private set; }

        [JsonProperty("From_Localised")]
        public string FromLocalised { get; private set; }

        [JsonProperty("Message")]
        public string Message { get; private set; }

        [JsonProperty("Message_Localised")]
        public string MessageLocalised { get; private set; }

        [JsonProperty("Channel")]
        public string Channel { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<ReceiveTextEvent> ReceiveTextEvent;

        internal void InvokeReceiveTextEvent(ReceiveTextEvent arg)
        {
            ReceiveTextEvent?.Invoke(this, arg);
        }
    }
}