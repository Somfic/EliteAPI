
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class NavBeaconScanEvent : EventBase
    {
        internal NavBeaconScanEvent() { }

        [JsonProperty("NumBodies")]
        public long NumBodies { get; private set; }
    }

    public partial class NavBeaconScanEvent
    {
        public static NavBeaconScanEvent FromJson(string json) => JsonConvert.DeserializeObject<NavBeaconScanEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<NavBeaconScanEvent> NavBeaconScanEvent;
        internal void InvokeNavBeaconScanEvent(NavBeaconScanEvent arg) => NavBeaconScanEvent?.Invoke(this, arg);
    }
}
