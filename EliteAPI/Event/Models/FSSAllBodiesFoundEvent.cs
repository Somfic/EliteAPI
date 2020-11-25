
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class FssAllBodiesFoundEvent : EventBase
    {
        internal FssAllBodiesFoundEvent() { }

        [JsonProperty("SystemName")]
        public string SystemName { get; private set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; private set; }

        [JsonProperty("Count")]
        public long Count { get; private set; }
    }

    public partial class FssAllBodiesFoundEvent
    {
        public static FssAllBodiesFoundEvent FromJson(string json) => JsonConvert.DeserializeObject<FssAllBodiesFoundEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<FssAllBodiesFoundEvent> FssAllBodiesFoundEvent;
        internal void InvokeFssAllBodiesFoundEvent(FssAllBodiesFoundEvent arg) => FssAllBodiesFoundEvent?.Invoke(this, arg);
    }
}
