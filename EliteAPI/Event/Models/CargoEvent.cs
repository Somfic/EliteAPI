
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class CargoEvent : EventBase
    {
        internal CargoEvent() { }

        [JsonProperty("Vessel")]
        public string Vessel { get; private set; }

        [JsonProperty("Count")]
        public long Count { get; private set; }

        [JsonProperty("Inventory")]
        public IReadOnlyList<object> Inventory { get; private set; }
    }

    public partial class CargoEvent
    {
        public static CargoEvent FromJson(string json) => JsonConvert.DeserializeObject<CargoEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<CargoEvent> CargoEvent;
        internal void InvokeCargoEvent(CargoEvent arg) => CargoEvent?.Invoke(this, arg);
    }
}
