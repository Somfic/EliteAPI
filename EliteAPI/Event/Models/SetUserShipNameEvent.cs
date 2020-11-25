
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class SetUserShipNameEvent : EventBase
    {
        internal SetUserShipNameEvent() { }

        [JsonProperty("Ship")]
        public string Ship { get; private set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; private set; }

        [JsonProperty("UserShipName")]
        public string UserShipName { get; private set; }

        [JsonProperty("UserShipId")]
        public string UserShipId { get; private set; }
    }

    public partial class SetUserShipNameEvent
    {
        public static SetUserShipNameEvent FromJson(string json) => JsonConvert.DeserializeObject<SetUserShipNameEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<SetUserShipNameEvent> SetUserShipNameEvent;
        internal void InvokeSetUserShipNameEvent(SetUserShipNameEvent arg) => SetUserShipNameEvent?.Invoke(this, arg);
    }
}
