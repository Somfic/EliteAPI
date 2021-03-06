using System;
using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class OutfittingEvent : EventBase
    {
        internal OutfittingEvent()
        {
        }

        [JsonProperty("MarketID")] public long MarketId { get; private set; }

        [JsonProperty("StationName")] public string StationName { get; private set; }

        [JsonProperty("StarSystem")] public string StarSystem { get; private set; }
    }

    public partial class OutfittingEvent
    {
        public static OutfittingEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<OutfittingEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<OutfittingEvent> OutfittingEvent;

        internal void InvokeOutfittingEvent(OutfittingEvent arg)
        {
            OutfittingEvent?.Invoke(this, arg);
        }
    }
}