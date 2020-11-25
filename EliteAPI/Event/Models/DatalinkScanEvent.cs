
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class DatalinkScanEvent : EventBase
    {
        internal DatalinkScanEvent() { }

        [JsonProperty("Message")]
        public string Message { get; private set; }

        [JsonProperty("Message_Localised")]
        public string MessageLocalised { get; private set; }
    }

    public partial class DatalinkScanEvent
    {
        public static DatalinkScanEvent FromJson(string json) => JsonConvert.DeserializeObject<DatalinkScanEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<DatalinkScanEvent> DatalinkScanEvent;
        internal void InvokeDatalinkScanEvent(DatalinkScanEvent arg) => DatalinkScanEvent?.Invoke(this, arg);
    }
}
