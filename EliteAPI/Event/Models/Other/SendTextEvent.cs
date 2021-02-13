using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class SendTextEvent : EventBase
    {
        internal SendTextEvent() { }

        [JsonProperty("To")]
        public string To { get; private set; }

        [JsonProperty("Message")]
        public string Message { get; private set; }

        [JsonProperty("Sent")]
        public bool Sent { get; private set; }
    }

    public partial class SendTextEvent
    {
        public static SendTextEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<SendTextEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<SendTextEvent> SendTextEvent;

        internal void InvokeSendTextEvent(SendTextEvent arg)
        {
            SendTextEvent?.Invoke(this, arg);
        }
    }
}