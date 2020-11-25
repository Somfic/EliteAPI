
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class FuelScoopEvent : EventBase
    {
        internal FuelScoopEvent() { }

        [JsonProperty("Scooped")]
        public double Scooped { get; private set; }

        [JsonProperty("Total")]
        public double Total { get; private set; }
    }

    public partial class FuelScoopEvent
    {
        public static FuelScoopEvent FromJson(string json) => JsonConvert.DeserializeObject<FuelScoopEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<FuelScoopEvent> FuelScoopEvent;
        internal void InvokeFuelScoopEvent(FuelScoopEvent arg) => FuelScoopEvent?.Invoke(this, arg);
    }
}
