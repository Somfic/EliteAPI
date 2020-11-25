
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class RestockVehicleEvent : EventBase
    {
        internal RestockVehicleEvent() { }

        [JsonProperty("Type")]
        public string Type { get; private set; }

        [JsonProperty("Loadout")]
        public string Loadout { get; private set; }

        [JsonProperty("Cost")]
        public long Cost { get; private set; }

        [JsonProperty("Count")]
        public long Count { get; private set; }
    }

    public partial class RestockVehicleEvent
    {
        public static RestockVehicleEvent FromJson(string json) => JsonConvert.DeserializeObject<RestockVehicleEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<RestockVehicleEvent> RestockVehicleEvent;
        internal void InvokeRestockVehicleEvent(RestockVehicleEvent arg) => RestockVehicleEvent?.Invoke(this, arg);
    }
}
