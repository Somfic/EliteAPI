
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class FighterRebuiltEvent : EventBase
    {
        internal FighterRebuiltEvent() { }

        [JsonProperty("Loadout")]
        public string Loadout { get; private set; }

        [JsonProperty("ID")]
        public long Id { get; private set; }
    }

    public partial class FighterRebuiltEvent
    {
        public static FighterRebuiltEvent FromJson(string json) => JsonConvert.DeserializeObject<FighterRebuiltEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<FighterRebuiltEvent> FighterRebuiltEvent;
        internal void InvokeFighterRebuiltEvent(FighterRebuiltEvent arg) => FighterRebuiltEvent?.Invoke(this, arg);
    }
}
