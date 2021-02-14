using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class NavBeaconScanEvent : EventBase<NavBeaconScanEvent>
    {
        internal NavBeaconScanEvent() { }

        [JsonProperty("NumBodies")]
        public long NumBodies { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<NavBeaconScanEvent> NavBeaconScanEvent;

        internal void InvokeNavBeaconScanEvent(NavBeaconScanEvent arg)
        {
            NavBeaconScanEvent?.Invoke(this, arg);
        }
    }
}