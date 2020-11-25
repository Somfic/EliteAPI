
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class ScannedEvent : EventBase
    {
        internal ScannedEvent() { }

        [JsonProperty("ScanType")]
        public string ScanType { get; private set; }
    }

    public partial class ScannedEvent
    {
        public static ScannedEvent FromJson(string json) => JsonConvert.DeserializeObject<ScannedEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<ScannedEvent> ScannedEvent;
        internal void InvokeScannedEvent(ScannedEvent arg) => ScannedEvent?.Invoke(this, arg);
    }
}
