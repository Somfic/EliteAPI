
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class PowerplayDeliverEvent : EventBase
    {
        internal PowerplayDeliverEvent() { }

        [JsonProperty("Power")]
        public string Power { get; private set; }

        [JsonProperty("Type")]
        public string Type { get; private set; }

        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; private set; }

        [JsonProperty("Count")]
        public long Count { get; private set; }
    }

    public partial class PowerplayDeliverEvent
    {
        public static PowerplayDeliverEvent FromJson(string json) => JsonConvert.DeserializeObject<PowerplayDeliverEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<PowerplayDeliverEvent> PowerplayDeliverEvent;
        internal void InvokePowerplayDeliverEvent(PowerplayDeliverEvent arg) => PowerplayDeliverEvent?.Invoke(this, arg);
    }
}
