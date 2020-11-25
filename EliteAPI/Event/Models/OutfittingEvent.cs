
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class OutfittingEvent : EventBase
    {
        internal OutfittingEvent() { }

        [JsonProperty("MarketID")]
        public long MarketId { get; private set; }

        [JsonProperty("StationName")]
        public string StationName { get; private set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; private set; }
    }

    public partial class OutfittingEvent
    {
        public static OutfittingEvent FromJson(string json) => JsonConvert.DeserializeObject<OutfittingEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<OutfittingEvent> OutfittingEvent;
        internal void InvokeOutfittingEvent(OutfittingEvent arg) => OutfittingEvent?.Invoke(this, arg);
    }
}
