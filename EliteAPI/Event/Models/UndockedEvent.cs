
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class UndockedEvent : EventBase
    {
        internal UndockedEvent() { }

        [JsonProperty("StationName")]
        public string StationName { get; private set; }

        [JsonProperty("StationType")]
        public string StationType { get; private set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; private set; }
    }

    public partial class UndockedEvent
    {
        public static UndockedEvent FromJson(string json) => JsonConvert.DeserializeObject<UndockedEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<UndockedEvent> UndockedEvent;
        internal void InvokeUndockedEvent(UndockedEvent arg) => UndockedEvent?.Invoke(this, arg);
    }
}
