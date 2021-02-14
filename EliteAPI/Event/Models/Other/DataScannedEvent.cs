using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class DataScannedEvent : EventBase<DataScannedEvent>
    {
        internal DataScannedEvent() { }

        [JsonProperty("Type")]
        public string Type { get; private set; }
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