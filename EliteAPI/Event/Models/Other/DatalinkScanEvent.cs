using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class DatalinkScanEvent : EventBase<DatalinkScanEvent>
    {
        internal DatalinkScanEvent() { }

        [JsonProperty("Message")]
        public string Message { get; private set; }

        [JsonProperty("Message_Localised")]
        public string MessageLocalised { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<DatalinkScanEvent> DatalinkScanEvent;

        internal void InvokeDatalinkScanEvent(DatalinkScanEvent arg)
        {
            DatalinkScanEvent?.Invoke(this, arg);
        }
    }
}