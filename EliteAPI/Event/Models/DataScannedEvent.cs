
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class DataScannedEvent : EventBase
    {
        internal DataScannedEvent() { }

        [JsonProperty("Type")]
        public string Type { get; private set; }
    }

    public partial class DataScannedEvent
    {
        public static DataScannedEvent FromJson(string json) => JsonConvert.DeserializeObject<DataScannedEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<DataScannedEvent> DataScannedEvent;
        internal void InvokeDataScannedEvent(DataScannedEvent arg) => DataScannedEvent?.Invoke(this, arg);
    }
}
