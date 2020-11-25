
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class ReceiveTextEvent : EventBase
    {
        internal ReceiveTextEvent() { }

        [JsonProperty("From")]
        public string From { get; private set; }

        [JsonProperty("Message")]
        public string Message { get; private set; }

        [JsonProperty("Channel")]
        public string Channel { get; private set; }
    }

    public partial class ReceiveTextEvent
    {
        public static ReceiveTextEvent FromJson(string json) => JsonConvert.DeserializeObject<ReceiveTextEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<ReceiveTextEvent> ReceiveTextEvent;
        internal void InvokeReceiveTextEvent(ReceiveTextEvent arg) => ReceiveTextEvent?.Invoke(this, arg);
    }
}
