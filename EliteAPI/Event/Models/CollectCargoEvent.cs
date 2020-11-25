
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class CollectCargoEvent : EventBase
    {
        internal CollectCargoEvent() { }

        [JsonProperty("Type")]
        public string Type { get; private set; }

        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; private set; }

        [JsonProperty("Stolen")]
        public bool Stolen { get; private set; }
    }

    public partial class CollectCargoEvent
    {
        public static CollectCargoEvent FromJson(string json) => JsonConvert.DeserializeObject<CollectCargoEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<CollectCargoEvent> CollectCargoEvent;
        internal void InvokeCollectCargoEvent(CollectCargoEvent arg) => CollectCargoEvent?.Invoke(this, arg);
    }
}
