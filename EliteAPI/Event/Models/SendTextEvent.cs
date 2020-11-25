
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


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
        public static SendTextEvent FromJson(string json) => JsonConvert.DeserializeObject<SendTextEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<SendTextEvent> SendTextEvent;
        internal void InvokeSendTextEvent(SendTextEvent arg) => SendTextEvent?.Invoke(this, arg);
    }
}
