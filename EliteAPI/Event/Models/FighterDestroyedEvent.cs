
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class FighterDestroyedEvent : EventBase
    {
        internal FighterDestroyedEvent() { }

        [JsonProperty("ID")]
        public long Id { get; private set; }
    }

    public partial class FighterDestroyedEvent
    {
        public static FighterDestroyedEvent FromJson(string json) => JsonConvert.DeserializeObject<FighterDestroyedEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<FighterDestroyedEvent> FighterDestroyedEvent;
        internal void InvokeFighterDestroyedEvent(FighterDestroyedEvent arg) => FighterDestroyedEvent?.Invoke(this, arg);
    }
}
