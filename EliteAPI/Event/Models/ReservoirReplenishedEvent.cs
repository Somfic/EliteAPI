
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class ReservoirReplenishedEvent : EventBase
    {
        internal ReservoirReplenishedEvent() { }

        [JsonProperty("FuelMain")]
        public double FuelMain { get; private set; }

        [JsonProperty("FuelReservoir")]
        public double FuelReservoir { get; private set; }
    }

    public partial class ReservoirReplenishedEvent
    {
        public static ReservoirReplenishedEvent FromJson(string json) => JsonConvert.DeserializeObject<ReservoirReplenishedEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<ReservoirReplenishedEvent> ReservoirReplenishedEvent;
        internal void InvokeReservoirReplenishedEvent(ReservoirReplenishedEvent arg) => ReservoirReplenishedEvent?.Invoke(this, arg);
    }
}
