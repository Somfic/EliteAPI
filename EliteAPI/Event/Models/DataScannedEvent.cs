using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class DataScannedEvent : EventBase
    {
        internal DataScannedEvent() { }

        [JsonProperty("Type")]
        public string Type { get; private set; }
    }

    public partial class DataScannedEvent
    {
        public static DataScannedEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<DataScannedEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<DataScannedEvent> DataScannedEvent;

        internal void InvokeDataScannedEvent(DataScannedEvent arg)
        {
            DataScannedEvent?.Invoke(this, arg);
        }
    }
}