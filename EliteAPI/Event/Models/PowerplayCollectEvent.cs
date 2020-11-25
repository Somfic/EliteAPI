
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class PowerplayCollectEvent : EventBase
    {
        internal PowerplayCollectEvent() { }

        [JsonProperty("Power")]
        public string Power { get; private set; }

        [JsonProperty("Type")]
        public string Type { get; private set; }

        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; private set; }

        [JsonProperty("Count")]
        public long Count { get; private set; }
    }

    public partial class PowerplayCollectEvent
    {
        public static PowerplayCollectEvent FromJson(string json) => JsonConvert.DeserializeObject<PowerplayCollectEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<PowerplayCollectEvent> PowerplayCollectEvent;
        internal void InvokePowerplayCollectEvent(PowerplayCollectEvent arg) => PowerplayCollectEvent?.Invoke(this, arg);
    }
}
