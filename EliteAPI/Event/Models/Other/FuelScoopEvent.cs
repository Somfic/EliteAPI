using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
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
        public static FuelScoopEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<FuelScoopEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<FuelScoopEvent> FuelScoopEvent;

        internal void InvokeFuelScoopEvent(FuelScoopEvent arg)
        {
            FuelScoopEvent?.Invoke(this, arg);
        }
    }
}